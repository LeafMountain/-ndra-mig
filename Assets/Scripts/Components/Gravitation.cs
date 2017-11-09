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

	float gravity;

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
		if(!IsGrounded){
			if(gravity < force){
				gravity += fallSpeed;
			}

			controller.Move(Vector3.down * gravity);

		} else if(gravity > 0 && IsGrounded) {
			gravity = 0;
		}
	}
}
