using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DrawLine : MonoBehaviour {

	public Transform from;
	public Transform to;

	LineRenderer lineRenderer;

	void Start(){
		lineRenderer = GetComponent<LineRenderer>();
	}

	void Update(){
		lineRenderer.SetPosition(0, from.position);
		lineRenderer.SetPosition(1, to.position);
	}
}
