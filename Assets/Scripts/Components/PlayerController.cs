using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Mover mover;
	private Jumper jumper;

	private CameraMovement cam;

	private void Start(){
		mover = GetComponent<Mover>();
		jumper = GetComponent<Jumper>();

		cam = GameObject.FindObjectOfType<CameraMovement>();
	}

	private void FixedUpdate(){
		if(mover){
			MoveInput();
		}
		if(jumper){
			JumpInput();
		}
	}

	private void MoveInput(){
		Vector3 verticalDirection = cam.Forward.normalized * Input.GetAxis("Vertical");
		Vector3 horizontalDirection = cam.Right.normalized * Input.GetAxis("Horizontal");
		bool sprint = Input.GetButton("Fire3");
		

		if(verticalDirection != Vector3.zero || horizontalDirection != Vector3.zero){
			mover.Move(verticalDirection + horizontalDirection, sprint);
		}
	}

	private void JumpInput(){
		if(Input.GetButton("Jump")){
			jumper.Jump();
		}
	}
}
