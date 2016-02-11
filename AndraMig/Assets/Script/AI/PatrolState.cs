using UnityEngine;
using System.Collections;

public class PatrolState : InterfaceAI {

	// Constructor variables and method.
	private readonly StateMachineAI stateMachine;
	public PatrolState(StateMachineAI stateMachineAI) {
		stateMachine = stateMachineAI;
		currentNodeInt = Random.Range(0, stateMachine.patrolNodes.Length);
		currentNode = stateMachine.patrolNodes[currentNodeInt].position;
	}

	// State-specific variables.
	private int currentNodeInt;
	private Vector3 currentNode;

	// Interface methods. ----------------------------------------------------------------

	public void UpdateState() {
		if (stateMachine.anim.GetBool("Walking") == false)
			stateMachine.anim.SetBool("Walking", true);
		RotateMe();
		MoveMe();
		CheckMe();
		Eyesight();
	}

	public void OnTriggerEnterState(Collider other) {
		if (other.gameObject == stateMachine.playerBuddy.gameObject) {
			ChangeState(stateMachine.chaseState);
		}
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

	void RotateMe() {
		stateMachine.transform.rotation = Quaternion.Lerp(stateMachine.transform.rotation, Quaternion.LookRotation(new Vector3(currentNode.x, stateMachine.transform.position.y, currentNode.z) - stateMachine.transform.position), Time.deltaTime * 5);
	}

	void MoveMe() {
		stateMachine.this_RB.MovePosition(stateMachine.transform.position + GetDirection(currentNode) * stateMachine.patrolSpeed * Time.fixedDeltaTime);
	}

	void CheckMe() {
		if (GetDistance(currentNode) <= 1f) {
			stateMachine.StartCoroutine(stateMachine.patrolState.NextNode());
		}
	}

	void Eyesight() {
		
	}

	public IEnumerator NextNode() {
		currentNodeInt = (currentNodeInt + 1) % stateMachine.patrolNodes.Length;
		currentNode = stateMachine.patrolNodes[currentNodeInt].position;
		stateMachine.currentState = stateMachine.idleState;
		yield return new WaitForSeconds(stateMachine.patrolIdleDelay);
		stateMachine.currentState = stateMachine.patrolState;
	}

	// State-switching method. -------------------------------------------------------------

	public void ChangeState(InterfaceAI state) {
		stateMachine.currentState = state;
	}

}