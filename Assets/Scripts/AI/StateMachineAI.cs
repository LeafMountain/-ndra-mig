using UnityEngine;
using System.Collections;

public class StateMachineAI : MonoBehaviour {

	// States.
	[HideInInspector] public AttackState attackState;
	[HideInInspector] public ChaseState chaseState;
	[HideInInspector] public IdleState idleState;
	[HideInInspector] public PatrolState patrolState;
	[HideInInspector] public InterfaceAI currentState;

	// This GameObject.
	[HideInInspector] public Rigidbody this_RB;
	[HideInInspector] public Animator anim;

	// Buddy-related variables.
	[HideInInspector] public Transform playerBuddy;
	[HideInInspector] public Movement buddyScript;

	// Various other hidden variables.
	[HideInInspector] public float attackBuddyDistance;
	[HideInInspector] public GameObject tailCollider;

	// Variables to be manipulated through the inspector.
	[Header("Manipulate this enemy.")]
	[Tooltip("Set the walking speed for the enemy while patrolling.")]
	public float patrolSpeed;
	[Tooltip("Set the amount in seconds that the enemy will idle at each waypoint.")]
	public float patrolIdleDelay;
	[Tooltip("Set the enemy's speed for chasing the player.")]
	public float chaseSpeed;
	[Tooltip("Set the delay in seconds that the enemy will wait before performing another attack.")]
	public float attackIdleDelay;

	[Header("Set this enemy's waypoints.")]
	[Tooltip("Set \"Elements\" to the amount of waypoints this enemy will have,\nthen drag each empty GameObjects to each element index.")]
	public Transform[] patrolNodes;

	void Awake() {
		attackState = new AttackState(this);
		chaseState = new ChaseState(this);
		idleState = new IdleState(this);
		patrolState = new PatrolState(this);
		playerBuddy = GameObject.FindGameObjectWithTag("Player").transform;
		buddyScript = playerBuddy.GetComponent<Movement>();
	}

	void Start() {
		this_RB = GetComponent<Rigidbody>();
		currentState = patrolState;
		anim = GetComponent<Animator>();
		tailCollider = transform.GetChild(2).gameObject;
		attackBuddyDistance = playerBuddy.gameObject.GetComponent<CapsuleCollider>().bounds.size.z;
	}

	void FixedUpdate() {
		currentState.UpdateState();
		anim.SetFloat("Speed", this_RB.velocity.magnitude);
	}

	void OnTriggerEnter(Collider other) {
		currentState.OnTriggerEnterState(other);
	}

}