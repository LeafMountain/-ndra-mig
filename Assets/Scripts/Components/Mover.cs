using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Mover : MonoBehaviour {

	public float normalSpeed = .1f;
	public float sprintSpeed = .2f;

	float currentSpeed;
	float targetSpeed;
	float speedSmoothVelocity;
	float speedSmoothTime = .1f;

	CharacterController controller;

	Vector3 velocity;
	public float Velocity { get{ return velocity.magnitude; } }

	[HideInInspector]
	public float currentSpeedPercentage;

	Vector3 lastPosition;

	void Start(){
		controller = GetComponent<CharacterController>();
	}

	void Update(){
		velocity = (lastPosition - transform.position);
		lastPosition = transform.position;

		currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);
		currentSpeedPercentage = currentSpeed / sprintSpeed;

		targetSpeed = 0;
	}

	public void Move(Vector3 moveDirection, bool sprint = false){
		targetSpeed = ((sprint) ? sprintSpeed : normalSpeed);
		controller.Move(moveDirection * currentSpeed);
		transform.LookAt(moveDirection + transform.position);
	}
}
