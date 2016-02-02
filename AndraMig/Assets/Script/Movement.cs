using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float acceleration = 40;                     //How fast the character will accelerate
    public float maxSpeed = 5;                          //The velocity limit
    public float turnSpeed = 10;                        //Rotation speed
    public float jumpForce = 15;                        //The force applied on the y axis when trying to jump
    public float jumpDelay = 0.8f;                      //Can't jump for jumpDelay amount of time
    public float jumpHeight = 5;
    public GameObject camera;
    public GameObject attackCol;

    private float verticalMovement;
    private float horizontalMovement;
    private Rigidbody rb;
    private float jumpTimer;
    private float jumpPower;                            //To keep track of how much jump power the player still has
    private Collider col;

    private Animator anim;

    bool jumpBool;


    private bool Grounded()
    {
        Ray distToGround = new Ray(new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), Vector3.down);
        Debug.DrawRay(distToGround.origin, distToGround.direction * 0.3f, Color.red);

        if (Physics.Raycast(distToGround, 0.3f))
            return true;
        else
            return false;
    }

    private bool Walled()
    {
        Ray distToWall = new Ray(col.bounds.center, rb.transform.forward);

        Debug.DrawRay(distToWall.origin, distToWall.direction * col.bounds.size.z, Color.blue);


        if (Physics.Raycast(distToWall, 0.2f))
            return true;
        else
            return false;
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
        float verticalMovement = Input.GetAxisRaw("Vertical");
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float inAirMultip;
        Vector3 moveForward = new Vector3(camera.transform.forward.x, 0, camera.transform.forward.z);
        Vector3 moveRight = new Vector3(camera.transform.right.x, 0, camera.transform.right.z);
        Vector3 lookRotation = moveForward * verticalMovement + moveRight * horizontalMovement;

        anim.SetFloat("Speed", rb.velocity.magnitude);

        if (lookRotation != Vector3.zero)
            rb.MoveRotation(Quaternion.Lerp(rb.rotation, Quaternion.LookRotation(lookRotation), Time.deltaTime * turnSpeed));


        if (Grounded())
            inAirMultip = 1;
        else
            inAirMultip = 0.7f;

        if (rb.velocity.magnitude < maxSpeed && !Walled())
            rb.AddForce(((moveForward * verticalMovement) * Time.deltaTime * acceleration) + ((moveRight * horizontalMovement) * Time.deltaTime * acceleration), ForceMode.VelocityChange);

    }

    void Jump()
    {
        bool jump = Input.GetButton("Jump");

        anim.SetBool("Jump", jumpBool);

        if (jump)
        {
            if (jumpPower > 0)
            {
                jumpPower -= Time.deltaTime * 30;
                jumpBool = true;
            }
            else if (jumpPower < 0)
            {
                jumpPower = 0;
            }

            rb.AddForce((Vector3.up * jumpForce) * jumpPower, ForceMode.Impulse);
        }
        if (Input.GetButtonUp("Jump"))
            jumpPower = 0;

        if (Grounded())
        {
            jumpPower = jumpHeight / 2;
            jumpBool = false;
        }
    }

    void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!Grounded())
                rb.AddForce((-rb.transform.up + rb.transform.forward) * acceleration, ForceMode.Impulse);
            anim.SetTrigger("Attack");
        }
        if (anim.GetFloat("AttackCollider") >= 0.9f)
            attackCol.SetActive(true);
        else if (anim.GetFloat("AttackCollider") < 0.9)
            attackCol.SetActive(false);
    }

    void RelodeLevel()
    {
        if (Input.GetButtonDown("Cancel"))
            Application.LoadLevel(Application.loadedLevel);
    }
}