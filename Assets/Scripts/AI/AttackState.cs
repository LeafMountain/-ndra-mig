using UnityEngine;
using System.Collections;

public class AttackState : InterfaceAI {

	// Constructor variable and method.
	private readonly StateMachineAI stateMachine;
	public AttackState(StateMachineAI stateMachineAI) {
		stateMachine = stateMachineAI;
	}

	// State-specific variables.

	// Interface methods. ----------------------------------------------------------------

	public void UpdateState() {
		RotateMe();

		if (GetDistance(stateMachine.playerBuddy.position) > 5f) {
			ChangeState(stateMachine.chaseState);
		} else {
			stateMachine.anim.SetTrigger("Attack");
		}
	}

	public void OnTriggerEnterState(Collider other) {}

	public Vector3 GetDirection(Vector3 target) {
		Vector3 targetDirection = target - stateMachine.transform.position;
		targetDirection.Normalize();
		return targetDirection;
	}

	public float GetDistance(Vector3 target) {
		return Vector3.Distance(stateMachine.transform.position, target);
	}

	// State-specific methods. ------------------------------------------------------------

	void RotateMe() {
		stateMachine.transform.rotation = Quaternion.Slerp(stateMachine.transform.rotation, Quaternion.LookRotation(GetDirection(stateMachine.playerBuddy.position)), 5f * Time.deltaTime);
	}

	// State-switching method. -----------------------------------------------------------

	public void ChangeState(InterfaceAI state) {
		stateMachine.currentState = state;
	}

}