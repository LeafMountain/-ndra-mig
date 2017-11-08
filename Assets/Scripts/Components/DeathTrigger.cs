using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class DeathTrigger : MonoBehaviour
{
    public void OnTriggerEnter (Collider col)
    {
        if(col.GetComponent<Health>()){
            col.GetComponent<Health>().Damage(99999);
        }
    }
}
