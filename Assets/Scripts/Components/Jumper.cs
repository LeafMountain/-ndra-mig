﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(Gravitation))]
public class Jumper : MonoBehaviour {

	public float jumpHeight;

	CharacterController controller;
	Gravitation gravity;

	void Start(){
		controller = GetComponent<CharacterController>();
		gravity = GetComponent<Gravitation>();
	}

	public void Jump(){
		if(gravity.IsGrounded){
			gravity.AddForce(Vector3.up, jumpHeight);
		}
	}
}
