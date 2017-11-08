using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour
{
    public GameObject currentSpawnPoint;
    GameObject buddy;

    public void Start ()
    {
        buddy = GameObject.FindGameObjectWithTag("Player");
    }

	
    public void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("dead.");
            Invoke("RespawnBuddy", 2);
        }

        if (col.gameObject.tag == "Enemy")
        {
            //col.transform.position = 
        }
    }

   public void RespawnBuddy ()
    {
        buddy.transform.position = currentSpawnPoint.transform.position;
    }

}
