using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Jumper : MonoBehaviour {

	public float jumpHeight = 2;

	private Rigidbody _rigidbody;
	public Rigidbody Rigidbody {
		get {
			if(_rigidbody == null){
				_rigidbody = GetComponent<Rigidbody>();
			}

			return _rigidbody;
		}
	}

	public void Jump(){
		if(GetComponent<Gravitation>().IsGrounded){
			Rigidbody.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
		}
	}
}
