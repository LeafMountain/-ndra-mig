using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Mover : MonoBehaviour {

	public float speed = .1f;
	public float sprintSpeed = .2f;

	CharacterController controller;

	Vector3 velocity;
	public float Velocity { get{ return velocity.magnitude; } }

	void Start(){
		controller = GetComponent<CharacterController>();
	}

	void Update(){
		velocity = controller.velocity;
	}

	public void Move(Vector3 moveDirection, bool sprint = false){
		float speed = ((sprint) ? sprintSpeed : this.speed);

		controller.Move(moveDirection * speed);

		transform.LookAt(transform.position + moveDirection);
	}
}
