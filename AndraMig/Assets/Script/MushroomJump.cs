using UnityEngine;
using System.Collections;

public class MushroomJump : MonoBehaviour
{
    public float addedForce = 200f;

    public void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * addedForce, ForceMode.Impulse);
            Debug.Log("bounce.");
        }
    }
}
