using UnityEngine;
using System.Collections;

public class Point : MonoBehaviour {

	void Update()
	{
		transform.rotation = transform.rotation * Quaternion.Euler(Vector3.up);
	}
	
	void OnTriggerStay(Collider col)
	{
		if(col.gameObject.tag == "Player")
		{
			Vector3 player = col.GetComponent<Collider>().bounds.center;
			transform.position = Vector3.MoveTowards(transform.position, player, Time.deltaTime * 10);
			if (transform.position == player)
				Destroy(gameObject);
		}
	}
}
