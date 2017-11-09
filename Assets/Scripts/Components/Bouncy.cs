using UnityEngine;
using System.Collections;

public class Bouncy : MonoBehaviour
{
    public enum BounceMode { Pushback, Up }

    public BounceMode mode;
    public float force = 200f;

    public void Bounce (Collider col) {
        Rigidbody rigidbody = col.GetComponent<Rigidbody>();

        if (rigidbody) {
            switch (mode) {
                case BounceMode.Pushback : 
                    rigidbody.AddForce((rigidbody.position - transform.position).normalized * force, ForceMode.Impulse);
                    break;

                case BounceMode.Up :
                    rigidbody.AddForce(Vector3.up * force, ForceMode.Impulse);
                    break;

                default:
                    break;
            }
        
        }
    }
}