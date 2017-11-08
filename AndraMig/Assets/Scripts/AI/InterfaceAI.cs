using UnityEngine;
using System.Collections;

public interface InterfaceAI {

	void UpdateState();

	void OnTriggerEnterState(Collider other);

	void ChangeState(InterfaceAI state);

	Vector3 GetDirection(Vector3 target);

	float GetDistance(Vector3 target);

}