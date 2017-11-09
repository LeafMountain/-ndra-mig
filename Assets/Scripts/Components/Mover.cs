using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour {

	public float acceleration = 20;
	public float maxSpeed = 7;
	public float sprintMultiplier = 2;

	public float Velocity { get{ return Rigidbody.velocity.magnitude; } }

	private Rigidbody _rigidbody;
	public Rigidbody Rigidbody {
		get {
			if(_rigidbody == null){
				_rigidbody = GetComponent<Rigidbody>();
			}

			return _rigidbody;
		}
	}

	public void Move(Vector3 moveDirection, bool sprint = false){
		float sprintMultip = ((sprint) ? sprintMultiplier : 1);

		if(Velocity < maxSpeed * sprintMultip){
			Rigidbody.AddForce(moveDirection * acceleration * sprintMultip, ForceMode.Acceleration);
		}

		transform.LookAt(transform.position + moveDirection);
	}
}
