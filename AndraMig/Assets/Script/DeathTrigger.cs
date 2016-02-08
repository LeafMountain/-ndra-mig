using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour
{
    GameObject spawnPoint;
    GameObject buddy;

    public void Start ()
    {
        buddy = GameObject.FindGameObjectWithTag("Player");
        spawnPoint = GameObject.Find("BuddySpawnPoint");
    }

	
    public void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("dead.");
            Invoke("RespawnBuddy", 2);
        }
    }

    public void RespawnBuddy ()
    {
        buddy.transform.position = spawnPoint.transform.position;
    }
}
