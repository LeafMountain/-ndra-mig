using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class Gravitation : MonoBehaviour {

	public float yOffset = .1f;
	public float distanceToGround = .5f;

	public bool IsGrounded {
		get {
			float height = distanceToGround + yOffset;
			Ray groundCheck = new Ray(collider.bounds.min + Vector3.up * yOffset, Vector3.down);
			return Physics.Raycast(groundCheck, height);
		}
	}
	private CapsuleCollider collider;

	void Start(){
		collider = GetComponent<CapsuleCollider>();
	}
}
