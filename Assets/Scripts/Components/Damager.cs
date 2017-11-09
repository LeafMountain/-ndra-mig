using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Damager : MonoBehaviour {

    [SerializeField]
    int damage;

    public void Damage (Collider col)
    {
        if(col.GetComponent<Health>()){
            col.GetComponent<Health>().Damage(damage);
        }
    }
}
