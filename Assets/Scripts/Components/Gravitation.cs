using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Gravitation : MonoBehaviour {
	[Space]
	public float yOffset = .1f;
	public float distanceToGround = .5f;

	public float gravity = -12;

	float velocityY;
	Vector3 addedVelocity;

	public bool IsGrounded {
		get {
			float height = distanceToGround + yOffset;
			Ray groundCheck = new Ray(controller.bounds.min + Vector3.up * yOffset, Vector3.down);
			return Physics.Raycast(groundCheck, height);
		}
	}

	CharacterController controller;

	void Start(){
		controller = GetComponent<CharacterController>();
	}

	void Update(){
		//Gravity
		velocityY += gravity * Time.deltaTime;

		//Add velocities together
		Vector3 velocity = addedVelocity + Vector3.up * velocityY;

		//Apply velocity
		controller.Move(velocity * Time.deltaTime);

		if(IsGrounded){
			addedVelocity = Vector3.zero;
			velocityY = 0;
		}
	}

	public void AddForce(Vector3 direction, float force){
		float addVelocity = Mathf.Sqrt(-2 * gravity * force);
		addedVelocity = direction * addVelocity;
	}
}
