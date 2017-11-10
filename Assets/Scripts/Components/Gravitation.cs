using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Gravitation : MonoBehaviour {

	public float force = 0.2f;
	public float fallSpeed = 1;

	[Space]
	public float yOffset = .1f;
	public float distanceToGround = .5f;

	public float gravity = -12;

	Vector3 velocity;

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
		controller.Move(Vector3.up * gravity * Time.deltaTime);

		//Gravity
		this.velocity.y += gravity * Time.deltaTime;
		
		// Vector3 velocity = Vector3.up * velocityY;
		controller.Move(velocity * Time.deltaTime);

		if(IsGrounded){
			velocity.y = 0;
		}
	}

	public void AddForce(Vector3 direction, float force){
		float velocity = Mathf.Sqrt(-2 * gravity * force);
	}
}
