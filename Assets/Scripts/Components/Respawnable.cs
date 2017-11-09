using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawnable : MonoBehaviour {

	public Vector3 spawnPoint;

	void Start(){
		spawnPoint = transform.position;
	}

	public void Respawn(){
		Health health = GetComponent<Health>();
		health.Heal(health.maxHealth);
		transform.position = spawnPoint;
	}

	public void SetSpawnPoint(Vector3 spawnPoint){
		this.spawnPoint = spawnPoint;
	}
}
