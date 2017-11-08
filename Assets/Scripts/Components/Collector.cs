using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collector : MonoBehaviour {

	public UnityEvent OnCollected;

	public void Collected(int amount){
		OnCollected.Invoke();
	}
}
