using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float acceleration = 20;             //How fast the character will accelerate
    public float maxSpeed;                      //The velocity limit
    public float turnSpeed = 200;               //Rotation speed
    public float jumpForce = 80;                //The force applied on the y axis when trying to jump
    public float jumpDelay;                     //Can't jump for jumpDelay amount of time
    public float jumpHeight;

    private float verticalMovement;
    private float horizontalMovement;
    private Rigidbody rb;
    private float jumpTimer;
    private float jumpPower;                    //To keep track of how much jump power the player still has
    private Collider col;



    private bool Grounded()
    {
        Ray distToGround = new Ray(transform.position, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(distToGround, out hit) && Vector3.Distance(transform.position, hit.point) < 1.2f)
            return true;
        else
            return false;
    }

    private bool Walled()
    {
        Ray distToWall = new Ray(transform.position, Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(distToWall, out hit) && Vector3.Distance(transform.position, hit.point) < col.bounds.size.z)
            return true;
        else
            return false;
    }


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }

    void FixedUpdate()
    {
        Run();
        Jump();
    }

    void Run()
    {
        float verticalMovement = Input.GetAxisRaw("Vertical") * Time.deltaTime * acceleration;
        float horizontalMovement = Input.GetAxisRaw("Horizontal") * Time.deltaTime * turnSpeed;
        float inAirMultip;

        if (Grounded())
            inAirMultip = 1;
        else
            inAirMultip = 0.5f;

        if (rb.velocity.magnitude < maxSpeed && verticalMovement != 0)
        {
            if (!Walled() && verticalMovement > 0)
                rb.AddForce(transform.forward * verticalMovement * inAirMultip, ForceMode.VelocityChange);
            else if (verticalMovement < 0)
                rb.AddForce(transform.forward * verticalMovement * inAirMultip, ForceMode.VelocityChange);
        }


        if (horizontalMovement != 0)
            rb.MoveRotation(rb.rotation * Quaternion.Euler(rb.rotation.x, rb.rotation.y + horizontalMovement, rb.rotation.z));
    }

    void Jump()
    {
        bool jump = Input.GetButton("Jump");

        if (jump)
        {
            if (jumpPower > 0)
            {
                jumpPower -= Time.deltaTime * 30;
            }
            else if (jumpPower < 0)
                jumpPower = 0;

            rb.AddForce((Vector3.up * jumpForce) * jumpPower, ForceMode.Impulse);
        }
        if (Input.GetButtonUp("Jump"))
            jumpPower = 0;

        if (Grounded())
            jumpPower = jumpHeight / 2;
    }
}