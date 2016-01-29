using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    public GameObject cameraTarget;
    public float distanceToGround;
    public float distanceToTarget;
    public float smooth = 5;

    void LateUpdate()
    {
        if (Vector3.Distance(transform.position, cameraTarget.transform.position) > distanceToTarget)
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + transform.forward.x, cameraTarget.transform.position.y + distanceToGround, transform.position.z + transform.forward.z), Time.deltaTime * smooth);
        else if (Vector3.Distance(transform.position, cameraTarget.transform.position) < distanceToTarget * 0.8f)
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - transform.forward.x, cameraTarget.transform.position.y + distanceToGround, transform.position.z - transform.forward.z), Time.deltaTime * smooth);

        transform.LookAt(cameraTarget.transform.position);

        transform.position = Vector3.Lerp(transform.position, transform.position + transform.right * Input.GetAxisRaw("HorizontalRight"), Time.deltaTime * smooth);

        if (Input.GetButton("Fire1"))
            transform.position = Vector3.Lerp(transform.position, new Vector3(cameraTarget.transform.position.x - cameraTarget.transform.forward.x * distanceToTarget, cameraTarget.transform.position.y + distanceToGround, cameraTarget.transform.position.z - cameraTarget.transform.forward.z * distanceToTarget), Time.deltaTime * smooth);
    }
}
