﻿using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float acceleration = 40;                     //How fast the character will accelerate
    public float maxSpeed = 5;                          //The velocity limit
    public float turnSpeed = 10;                        //Rotation speed
    public float sprintMultip = 2;
    public float jumpForce = 15;                        //The force applied on the y axis when trying to jump
    public float jumpDelay = 0.8f;                      //Can't jump for jumpDelay amount of time
    public float jumpHeight = 5;
    public float gravity;
    public GameObject cam;
    public GameObject weapon;
    public GameObject attackCol;
    public AudioClip[] attackSound;
    public AudioClip[] footstepSound;

    private float verticalMovement;
    private float horizontalMovement;
    private Rigidbody rb;
    private float jumpTimer;
    private float jumpPower;                            //To keep track of how much jump power the player still has
    private Collider col;
    private Animator anim;
    private AudioSource audi;
    private float defaultTriggerRight;

    public bool isTalking = false;
    public bool talkRange = false;
    public GameObject currentNPC;
    public disenableUi dUI;

    void Start()
    {
        dUI = GetComponent<disenableUi>();
    }

    private bool Grounded()
    {
        Ray distToGround = new Ray(new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z), Vector3.down);
        Ray distToGroundFront = new Ray(new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.2f), Vector3.down);

        Debug.DrawRay(distToGround.origin, distToGround.direction * 0.4f, Color.blue);
        Debug.DrawRay(distToGroundFront.origin, distToGroundFront.direction * 0.5f, Color.red);

        return (Physics.Raycast(distToGround, 0.4f) || Physics.Raycast(distToGroundFront, 0.5f) ? true : false);
    }

    private bool Walled()
    {
        Ray top = new Ray(col.bounds.center + Vector3.up, transform.forward);
        Ray mid = new Ray(col.bounds.center, transform.forward);
        Ray low = new Ray(col.bounds.center + Vector3.down, transform.forward);

        return (Physics.Raycast(top, col.bounds.size.z) || Physics.Raycast(mid, col.bounds.size.z) || Physics.Raycast(low, col.bounds.size.z)) ? true : false;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        anim = GetComponent<Animator>();
        audi = GetComponent<AudioSource>();
        defaultTriggerRight = Input.GetAxisRaw("TriggerRight");
    }

    void FixedUpdate()
    {
		if (!isTalking)
        {
            Run();
            Jump();
			if (!talkRange)
	            Attack();
        }

        if (talkRange)
        {
            Conversate();
        }

        anim.SetBool("Grounded", Grounded());

        //Gravity
        if (!Grounded())
        {
            rb.AddForce(Vector3.down * gravity, ForceMode.Acceleration);
        }


    }

    void Run()
    {
        Vector3 moveForward = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z);
        Vector3 moveRight = new Vector3(cam.transform.right.x, 0, cam.transform.right.z);
        float sprint = (Input.GetAxisRaw("TriggerRight") != defaultTriggerRight) ? sprintMultip : 1;
        float horizontalVelocity = new Vector3(rb.velocity.x, 0, rb.velocity.z).magnitude;
        float inAirMultip = (Grounded()) ? 1 : 0.2f;
        Vector3 moveRotation = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z).normalized * Input.GetAxisRaw("Vertical") + new Vector3(cam.transform.right.x, 0, cam.transform.right.z).normalized * Input.GetAxisRaw("Horizontal") * inAirMultip;

        anim.SetFloat("Speed", horizontalVelocity);

        if (moveRotation != Vector3.zero)
            rb.MoveRotation(Quaternion.Lerp(rb.rotation, Quaternion.LookRotation(moveRotation), Time.deltaTime * turnSpeed));

        if (horizontalVelocity < maxSpeed * sprint && !Walled())
            rb.AddForce(moveRotation * acceleration * Time.deltaTime, ForceMode.VelocityChange);

    }

    void Jump()
    {
        bool jump = Input.GetButton("Jump");
        anim.SetBool("Jump", jump);

        if (jump)
        {
            jumpPower = (jumpPower > 0) ? jumpPower - Time.deltaTime * 30 : 0;
            rb.AddForce((Vector3.up * jumpForce) * jumpPower, ForceMode.Impulse);
        }

        jumpPower = (Input.GetButtonUp("Jump")) ? 0 : jumpPower;
        jumpPower = (Grounded()) ? jumpHeight / 2 : jumpPower;

    }

    void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!Grounded())
                rb.AddForce((-rb.transform.up + rb.transform.forward) * acceleration, ForceMode.Impulse);
            anim.SetTrigger("Attack");
        }
        attackCol.SetActive((anim.GetFloat("AttackCollider") >= 0.9f));
    }

    void Footstep()
    {
        PlayAudio(footstepSound[Random.Range(0, footstepSound.Length)], 0.1f);
    }

    void AttackSound()
    {
        PlayAudio(attackSound[Random.Range(0, attackSound.Length)], 1);
    }

    void WeaponEnabled(int enabled)
    {
        if (enabled == 1)
            weapon.SetActive(true);
        else
            weapon.SetActive(false);
    }

    void PlayAudio(AudioClip clip, float volume)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position, volume);
    }

    void Conversate()
    {
        dUI.canvas.enabled = true;
		if (Input.GetButtonDown("Fire1"))
        {
            currentNPC.GetComponent<NPC>().NPCState(true);
            talkRange = false;
            isTalking = true;
        }
    }
}