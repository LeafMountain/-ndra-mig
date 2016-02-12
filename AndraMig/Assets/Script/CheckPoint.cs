using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour
{
    public DeathTrigger dt;

    public void Start ()
    {
        dt = GameObject.Find("DeathTrigger").GetComponent<DeathTrigger>();
    }

    public void OnTriggerEnter (Collider col)
    {
		if (col.gameObject.tag == "Player")
		{
			dt.currentSpawnPoint = this.gameObject;
		}
    }
}
