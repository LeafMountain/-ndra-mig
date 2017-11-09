using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Jumper : MonoBehaviour {

	public float force = 2;
	private float forceLeft;

	CharacterController controller;
	Gravitation gravity;

	void Start(){
		controller = GetComponent<CharacterController>();
		gravity = GetComponent<Gravitation>();

		forceLeft = force;
	}

	public void Jump(){
		if(gravity.IsGrounded){
			controller.Move(Vector3.up * forceLeft);
			forceLeft *= .5f;
		} else if(forceLeft != force && gravity.IsGrounded){
			forceLeft = force;
		}
	}
}
