using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float acceleration = 20;             //How fast the character will accelerate
    public float maxSpeed;                      //The velocity limit
    public float turnSpeed = 200;               //Rotation speed
    public float jumpForce = 80;                //The force applied on the y axis when trying to jump
    public float jumpDelay;                     //Can't jump for jumpDelay amount of time

    private float verticalMovement;
    private float horizontalMovement;
    private float jump;
    private Rigidbody rb;
    private float jumpTimer;

    float jumpHeight;


    private bool onGround()
    {
        Ray distToGround = new Ray(transform.position, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(distToGround, out hit) && Vector3.Distance(transform.position, hit.point) < 1.2f)
            return true;
        else
            return false;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
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

        if (onGround())
            inAirMultip = 1;
        else
            inAirMultip = 0.5f;

        if (rb.velocity.magnitude < maxSpeed && verticalMovement != 0)
            rb.AddForce(transform.forward * verticalMovement * inAirMultip, ForceMode.VelocityChange);

        if (horizontalMovement != 0)
            rb.MoveRotation(rb.rotation * Quaternion.Euler(rb.rotation.x, rb.rotation.y + horizontalMovement, rb.rotation.z));
    }

    void Jump()
    {
        bool jump = Input.GetButton("Jump");

        if (jump)
        {
            if (jumpHeight > 0)
            {
                jumpHeight -= Time.deltaTime * 30;
            }

            rb.AddForce((Vector3.up * jumpForce) * jumpHeight, ForceMode.Impulse);
        }
        if (Input.GetButtonUp("Jump"))
            jumpHeight = 0;

        if (onGround())
            jumpHeight = jumpForce;
    }
}
