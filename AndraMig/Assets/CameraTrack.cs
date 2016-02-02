using UnityEngine;
using System.Collections;

public class CameraTrack : MonoBehaviour
{
    public GameObject nextTarget;
    public GameObject lookTarget;
    public GameObject camera;

    void Awake()
    {
    }

    void Update()
    {
        Debug.DrawLine(transform.position, nextTarget.transform.position, Color.red);

        if (Vector3.Distance(transform.position, camera.transform.position) < 11)
        {
            camera.GetComponent<CameraMovement>().ChangeTarget(nextTarget, lookTarget);

            gameObject.SetActive(false);

        }

    }
}
