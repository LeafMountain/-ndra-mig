using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;
    public float distanceFromTarget = 10;

    public Vector2 pitchMinMax = new Vector2(-8, 80);

    public float rotationSmoothTime = .12f;
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;

    float pitch;
    float yaw;

    [Range(0, 1)]
    public float lookSensitivity = 0.5f;
    float controllerSensitivityMultiplier = 4;

    public bool invertYaw;
    public bool invertPitch;

    void LateUpdate(){
        float invertYaw = (this.invertYaw) ? -1 : 1;
        float invertPitch = (this.invertPitch) ? -1 : 1;

        float verticalInput = (Input.GetAxis("Mouse Y") * lookSensitivity) + (-Input.GetAxis("LookVertical") * lookSensitivity * controllerSensitivityMultiplier);
        float horizontalInput = (Input.GetAxis("Mouse X") * lookSensitivity) + (-Input.GetAxis("LookHorizontal") * lookSensitivity * controllerSensitivityMultiplier);

        yaw += horizontalInput * invertYaw;
        pitch -= verticalInput * invertPitch;
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

        Vector3 targetRotation = new Vector3(pitch, yaw);        

        currentRotation = Vector3.SmoothDamp(currentRotation, targetRotation, ref rotationSmoothVelocity, rotationSmoothTime);   

        transform.eulerAngles = currentRotation;

        transform.position = target.position - transform.forward * distanceFromTarget;
    }
}
