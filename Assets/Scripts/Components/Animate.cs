using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Animate : MonoBehaviour {

	private Animator animator;
	private Mover mover;
	private Gravitation gravitation;

	private void Start(){
		animator = GetComponent<Animator>();
		mover = GetComponent<Mover>();
		gravitation = GetComponent<Gravitation>();
	}

	private void LateUpdate(){
		animator.SetBool("Grounded", gravitation.IsGrounded);

		if(mover){
			animator.SetFloat("Speed", mover.currentSpeedPercentage);
		}

		if(GetComponent<Jumper>()){
			animator.SetBool("Jump", GetComponent<Jumper>().jumped);
		}

	}
}
