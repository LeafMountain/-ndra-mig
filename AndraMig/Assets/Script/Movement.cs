using UnityEngine;
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
    public GameObject cam;
    public GameObject attackCol;

    private float verticalMovement;
    private float horizontalMovement;
    private Rigidbody rb;
    private float jumpTimer;
    private float jumpPower;                            //To keep track of how much jump power the player still has
    private Collider col;
    private Animator anim;

    private bool Grounded()
    {
        Ray distToGround = new Ray(new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), Vector3.down);
        return (Physics.Raycast(distToGround, 0.3f)) ? true : false;
    }

    private bool Walled()
    {
        Ray top = new Ray(col.bounds.center + Vector3.up, transform.forward);
        Ray mid = new Ray(col.bounds.center, transform.forward);
        Ray low = new Ray(col.bounds.center + Vector3.down, transform.forward);

        return (Physics.Raycast(top, col.bounds.size.z) || Physics.Raycast(mid, col.bounds.size.z) || Physics.Raycast(low, col.bounds.size.z)) ? true : false;
    }

    private bool LedgeGrab()
    {
        Ray top = new Ray(col.bounds.center + Vector3.up, transform.forward);
        Ray mid = new Ray(col.bounds.center, transform.forward);
        Ray low = new Ray(col.bounds.center + Vector3.down, transform.forward);

        Debug.DrawRay(top.origin, top.direction * col.bounds.size.z, Color.blue);
        Debug.DrawRay(mid.origin, mid.direction * col.bounds.size.z, Color.blue);
        Debug.DrawRay(low.origin, low.direction * col.bounds.size.z, Color.blue);

        return (!Physics.Raycast(top, col.bounds.size.z) && (Physics.Raycast(mid, col.bounds.size.z) || Physics.Raycast(low, col.bounds.size.z))) ? true : false;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Run();
        Jump();
        Attack();

        anim.SetBool("Grounded", Grounded());
    }

    void Run()
    {
        Vector3 moveForward = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z);
        Vector3 moveRight = new Vector3(cam.transform.right.x, 0, cam.transform.right.z);
        Vector3 moveRotation = moveForward * Input.GetAxisRaw("Vertical") + moveRight * Input.GetAxisRaw("Horizontal");
        float sprint = (Input.GetAxisRaw("TriggerRight") != 0) ? sprintMultip : 1;

        anim.SetFloat("Speed", rb.velocity.magnitude);

        if (moveRotation != Vector3.zero)
            rb.MoveRotation(Quaternion.Lerp(rb.rotation, Quaternion.LookRotation(moveRotation), Time.deltaTime * turnSpeed));

        if (rb.velocity.magnitude < maxSpeed * sprint && !Walled())
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
}