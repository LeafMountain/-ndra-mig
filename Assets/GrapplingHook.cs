using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour {

	public float grapplingForce = 1;

	GrapplingPoint point;

	public void SetGrapplingPoint(GrapplingPoint point){
		this.point = point;
	}

	public void RemoveGrapplingPoint(){
		point = null;
	}

	public void Grapple(){
		if(point){
			Vector3 grappleDirection = (point.transform.position - transform.position).normalized;
			
			GetComponent<Gravitation>().AddForce(grappleDirection + Vector3.up * 2, grapplingForce);
		}
	}
}
