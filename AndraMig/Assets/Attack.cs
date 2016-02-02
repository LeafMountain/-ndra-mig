using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{

    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<Rigidbody>())
        {
            col.GetComponent<Rigidbody>().AddForce((transform.forward + transform.up) * 10, ForceMode.Impulse);
        }
    }
}
