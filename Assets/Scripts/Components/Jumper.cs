using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Jumper : MonoBehaviour {

	public float force = 2;
	private float forceLeft;
	public float jumpHeight;

	CharacterController controller;
	Gravitation gravity;
	float _gravity = -12f;

	Vector3 velocity;
	float velocityY;

	void Start(){
		controller = GetComponent<CharacterController>();
		gravity = GetComponent<Gravitation>();

		forceLeft = force;
	}

	public void Jump(){
		if(gravity.IsGrounded){
			float jumpVelocity = Mathf.Sqrt(-2 * _gravity * jumpHeight);
			velocityY = jumpVelocity;
			// gravity.AddForce(Vector3.up, jumpHeight);
		}
	}

	void Update(){
		velocityY += _gravity * Time.deltaTime;
		Vector3 velocity = Vector3.up * velocityY;
		controller.Move(velocity * Time.deltaTime);

		if(controller.isGrounded){
			velocityY = 0;
		}
	}
}
