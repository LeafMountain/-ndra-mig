using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugText : MonoBehaviour {

	public void WriteToLog(Collider col){
		Debug.Log(col.name);
	}
}
