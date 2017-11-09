using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Mover : MonoBehaviour {

	public float acceleration = 20;
	public float speed = .1f;
	public float sprintSpeed = .2f;

	CharacterController controller;

	float velocity;
	public float Velocity { get{ return velocity; } }

	// private Rigidbody _rigidbody;
	// public Rigidbody Rigidbody {
	// 	get {
	// 		if(_rigidbody == null){
	// 			_rigidbody = GetComponent<Rigidbody>();
	// 		}

	// 		return _rigidbody;
	// 	}
	// }

	void Start(){
		controller = GetComponent<CharacterController>();
	}

	void Update(){
		velocity = GetComponent<CharacterController>().velocity.magnitude;
	}

	public void Move(Vector3 moveDirection, bool sprint = false){
		float speed = ((sprint) ? sprintSpeed : this.speed);

		GetComponent<CharacterController>().Move(moveDirection * speed);

		transform.LookAt(transform.position + moveDirection);
	}
}
