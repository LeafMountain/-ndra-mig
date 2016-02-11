using UnityEngine;
using System.Collections;

public class ChaseState : InterfaceAI {

	// Constructor variables and method.
	private readonly StateMachineAI stateMachine;
	public ChaseState(StateMachineAI stateMachineAI) {
		stateMachine = stateMachineAI;
		triggerWidth = stateMachine.GetComponent<SphereCollider>().bounds.size.z;
	}

	// State-specific variables.
	float triggerWidth;

	// Interface methods. ----------------------------------------------------------------

	public void UpdateState() {
		RotateMe();
		MoveMe();
		CheckMe();
	}

	public void OnTriggerEnterState(Collider other) {
		// Collisions.
	}

	public Vector3 GetDirection(Vector3 target) {
		Vector3 targetDirection = target - stateMachine.transform.position;
		targetDirection.Normalize();
		return targetDirection;
	}

	public float GetDistance(Vector3 target) {
		return Vector3.Distance(stateMachine.transform.position, target);
	}

	// State-specific methods. -----------------------------------------------------------

	void RotateMe() {
		stateMachine.transform.rotation = Quaternion.Slerp(stateMachine.transform.rotation, Quaternion.LookRotation(GetDirection(stateMachine.playerBuddy.position)), 5f * Time.deltaTime);
	}

	void MoveMe() {
		stateMachine.this_RB.MovePosition(stateMachine.transform.position + GetDirection(stateMachine.playerBuddy.position) * (stateMachine.chaseSpeed) * Time.fixedDeltaTime);
	}

	void CheckMe() {
		if (GetDistance(stateMachine.playerBuddy.position) <= stateMachine.attackBuddyDistance * 4)
			ChangeState(stateMachine.attackState);
		else if (GetDistance(stateMachine.playerBuddy.position) > triggerWidth * 1.5f)
			ChangeState(stateMachine.patrolState);
	}

	// State-switching method. ------------------------------------------------------------

	public void ChangeState(InterfaceAI state) {
		stateMachine.currentState = state;
	}

}