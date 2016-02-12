using UnityEngine;
using System.Collections;

public class SlenderToggler : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player")
			transform.GetChild(0).gameObject.SetActive(false);
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Player")
			transform.GetChild(0).gameObject.SetActive(true);
	}
}