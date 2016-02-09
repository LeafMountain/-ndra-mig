using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    public GameObject cameraTarget;     //The camera follows this game object
    public GameObject lookTarget;
    public float distanceToGround;      //How high from the ground the camera should be
    public float distanceToTarget;      //How far away from the target the camera should be
    public float smooth = 5;            //How smooth the camera follows (Higher = faster)

    void LateUpdate()
    {
        //How do we want to move the camera?
        Vector3 away = new Vector3(transform.position.x - transform.forward.x, cameraTarget.transform.position.y + distanceToGround, transform.position.z - transform.forward.z);
        Vector3 closer = new Vector3(transform.position.x + transform.forward.x, cameraTarget.transform.position.y + distanceToGround, transform.position.z + transform.forward.z);
        Vector3 behind = new Vector3(cameraTarget.transform.position.x - cameraTarget.transform.forward.x * distanceToTarget, cameraTarget.transform.position.y + distanceToGround, cameraTarget.transform.position.z - cameraTarget.transform.forward.z * distanceToTarget);
        Vector3 distToGr = new Vector3(0, distanceToGround, 0);
        float distance = Vector3.Distance(transform.position, lookTarget.transform.position);

        //Point the camera towards the target (Player)
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(((lookTarget.transform.position + Vector3.up) - transform.position)), Time.deltaTime * smooth);

        //Right joystick movement
        float hRight = Input.GetAxisRaw("HorizontalRight");
        float vRight = Input.GetAxisRaw("VerticalRight");

        //Moves camera by using right joystick
        if (hRight != 0 || vRight != 0)
            transform.position = Vector3.Lerp(transform.position, transform.position + transform.right * hRight + transform.up * vRight, Time.deltaTime * smooth * 5);
        //Press Fire1 to put camera behind target
        if (Input.GetAxisRaw("TriggerLeft") != 1)
            transform.position = Vector3.Lerp(transform.position, behind, Time.deltaTime * smooth);
        //Move with target

        else
        {
            /*
            if (Vector3.Distance(transform.position, cameraTarget.transform.position) > distanceToTarget)
                transform.position = Vector3.MoveTowards(transform.position, cameraTarget.transform.position + distToGr, Time.deltaTime * smooth * (distance / 10));
            else if (Vector3.Distance(transform.position, cameraTarget.transform.position) < distanceToTarget * 0.8f)
                transform.position = Vector3.Lerp(transform.position, away, Time.deltaTime * smooth * 1.2f);  */

            if (Vector3.Distance(transform.position, cameraTarget.transform.position) > distanceToTarget)
            {
                transform.position = Vector3.MoveTowards(transform.position, cameraTarget.transform.position + distToGr, Time.deltaTime * smooth * (distance / 10));
            }
        }
    }

    public void ChangeTarget(GameObject target, GameObject look)
    {
        cameraTarget = target;
        if (look == null)
            lookTarget = target;
        else
            lookTarget = look;
    }
}
