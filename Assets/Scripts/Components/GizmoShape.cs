using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoShape : MonoBehaviour {
	public enum Shape { Cube, Sphere }

	public Shape shape = Shape.Cube;
	public Color gizmoColor = Color.black;
	public Vector3 size = Vector3.one;
	public bool useColliderSize;

	Collider collider;

	void OnDrawGizmos(){
		collider = GetComponent<Collider>();

		if(useColliderSize){
			if(GetComponent<BoxCollider>()){
				Vector3 colliderSize = GetComponent<BoxCollider>().size;
				size =  new Vector3(transform.localScale.x * colliderSize.x, transform.localScale.y * colliderSize.y, transform.localScale.z * colliderSize.z);
			} else if(GetComponent<SphereCollider>()){
				size.x = GetComponent<SphereCollider>().radius;
			}
		}

		Gizmos.color = gizmoColor;
		
		if(shape == Shape.Cube){
			Matrix4x4 originalMatix = Gizmos.matrix;
			Matrix4x4 cubeTransform = Matrix4x4.TRS(collider.bounds.center, transform.rotation, size);
			Gizmos.matrix *= cubeTransform;
			Gizmos.DrawCube(Vector3.zero, Vector3.one);
			Gizmos.matrix = originalMatix;
			
		} else if(shape == Shape.Sphere) {
			Gizmos.DrawSphere(Vector3.zero, size.x);
			
		}
	}
}
