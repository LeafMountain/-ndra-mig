using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Trigger : MonoBehaviour {

	public UnityTriggerEvent OnTriggerEntered;
	public UnityTriggerEvent OnTriggerExited;
	
	void OnTriggerEnter(Collider col){
		OnTriggerEntered.Invoke(col);
	}

	void OnTriggerExit(Collider col){
		OnTriggerExited.Invoke(col);
	}

}

[System.Serializable]
public class UnityTriggerEvent : UnityEvent<Collider> { }
