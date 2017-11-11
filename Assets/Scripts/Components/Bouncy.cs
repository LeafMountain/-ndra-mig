using UnityEngine;
using System.Collections;

public class Bouncy : MonoBehaviour
{
    public enum BounceMode { Pushback, Up }

    public BounceMode mode;
    public float force = 200f;

    public void Bounce (Collider col) {
        Gravitation gravity = col.GetComponent<Gravitation>();

        if (gravity) {
            switch (mode) {
                case BounceMode.Pushback : 
                    gravity.AddForce((gravity.transform.position - transform.position).normalized, force);
                    break;

                case BounceMode.Up :
                    gravity.AddForce(Vector3.up, force);
                    break;

                default:
                    break;
            }
        
        }
    }
}