using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class Gravitation : MonoBehaviour {

	public bool IsGrounded {
		get {
			float height = .5f;
			Ray groundCheck = new Ray(collider.bounds.min, Vector3.down);
			return Physics.Raycast(groundCheck, height);
		}
	}
	private CapsuleCollider collider;

	void Start(){
		collider = GetComponent<CapsuleCollider>();
	}
}
