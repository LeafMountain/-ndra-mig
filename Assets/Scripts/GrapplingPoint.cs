using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingPoint : MonoBehaviour {

	public void SetGrapplingPoint(Collider col){
		GrapplingHook hook = col.GetComponent<GrapplingHook>();

		if(hook){
			hook.SetGrapplingPoint(this);
		}
	}

	public void RemoveGrapplingPoint(Collider col){
		GrapplingHook hook = col.GetComponent<GrapplingHook>();

		if(hook){
			hook.RemoveGrapplingPoint();
		}
	}
}
