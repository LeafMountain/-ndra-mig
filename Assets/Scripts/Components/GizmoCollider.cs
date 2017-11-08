using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoCollider : MonoBehaviour {
	private enum Shape { Cube, Sphere }

	public Color gizmoColor = Color.black;
	public Vector3 size = Vector3.one;
	public bool useColliderSize;

	void OnDrawGizmos(){
		Matrix4x4 cubeTransform = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);
		Gizmos.color = gizmoColor;
		Gizmos.matrix *= cubeTransform;

		if(useColliderSize){
			size = GetComponent<Collider>().bounds.size;
		}			

		Gizmos.DrawCube(Vector3.zero, Vector3.one);
	}
}
