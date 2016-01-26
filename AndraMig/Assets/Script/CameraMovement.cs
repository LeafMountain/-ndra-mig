using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    public GameObject cameraPosition;

    public float smooth = 5;
    [HideInInspector]
    public Transform cameraPos;

    void Update()
    {
        transform.LookAt(cameraPosition.transform.position);
        transform.position = Vector3.Lerp(transform.position, cameraPosition.transform.position, Time.deltaTime * smooth);
    }

    void LateUpdate()
    {
        transform.LookAt(cameraPosition.transform.parent.position);
    }
}
