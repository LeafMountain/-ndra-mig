using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class CheckPoint : MonoBehaviour
{
    public void OnTriggerEnter (Collider col)
    {
		if (col.GetComponent<Respawnable>()) {
			col.GetComponent<Respawnable>().spawnPoint = transform.position;
		}
    }
}
