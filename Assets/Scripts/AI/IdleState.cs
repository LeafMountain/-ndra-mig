using UnityEngine;
using System.Collections;

public class IdleState : InterfaceAI {

	// Constructor variable and method.
	private readonly StateMachineAI stateMachine;
	public IdleState(StateMachineAI stateMachineAI) {
		stateMachine = stateMachineAI;
	}

	// State-specific variables.
	private bool hasRunOnce = false;

	// Interface methods. ----------------------------------------------------------------

	public void UpdateState() {
		if (!hasRunOnce) {
			hasRunOnce = true;
			stateMachine.anim.SetBool("Walking", false);
		}
	}

	public void OnTriggerEnterState(Collider other) {
		if (other.gameObject == stateMachine.playerBuddy.gameObject)
			ChangeState(stateMachine.chaseState);
	}

	public Vector3 GetDirection(Vector3 target) {
		Vector3 fullDirection = target - stateMachine.transform.position;
		Vector3 normalizedDirection = fullDirection / fullDirection.magnitude;
		return normalizedDirection;
	}

	public float GetDistance(Vector3 target) {
		return Vector3.Distance(stateMachine.transform.position, target);
	}

	// State-specific methods. ------------------------------------------------------------

	// State-switching method. -----------------------------------------------------------

	public void ChangeState(InterfaceAI state) {
		hasRunOnce = false;
		stateMachine.currentState = state;
	}

}