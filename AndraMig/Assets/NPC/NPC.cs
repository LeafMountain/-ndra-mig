using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NPC : MonoBehaviour {

	[Header("Don't edit manually - it's only for debugging!")]
	[Tooltip("InConvo is a bool for other scripts to reference and manipulate.")]
	public bool inConvo = false;
	[Tooltip("NPC State is for the npc script to keep track of what to do.")]
	public int npcState = 0;
	[Tooltip("This integer is keeping track of which message to display, from the Conversation Messages-array.")]
	public int i = 0;

	[Header("Manually edit NPCs messages.")]
	[Tooltip("Conversation Messages are those that the player will be clicking through.")]
	public string[] conversationMessages;

	bool clickable = false;
	private float timer = 0;


	private GameObject playerBuddy;
	Movement scriptReference;

	/*
	 * player needs:
	 * isTalking bool
	 * currentNPC GameObject
	 */

	// Canvas variables.
	public GameObject dialogueImage;
//	public Image dialogueImage; // Referencing players canvas for conversations.
	public Text dialogueText;

	void Awake() {
		playerBuddy = GameObject.FindGameObjectWithTag("Player");
	}

	void Start() {
		scriptReference = playerBuddy.GetComponent<Movement>();
		dialogueImage.SetActive(false);
//		dialogueImage.enabled = false;
//		dialogueText.enabled = false;
	}

	public void NPCState(bool state) {
		inConvo = state;
		npcState = (inConvo) ? 1 : 0;
		dialogueImage.SetActive(state);
//		dialogueImage.enabled = state;
//		dialogueText.enabled = state;
		clickable = state;
		if (inConvo) {
			ChatterTime();
		} else {
			dialogueText.text = "";
			i = 0;
			timer = 0;
		}
	}

	void Update() {
		if (clickable && Input.GetKeyDown(KeyCode.C)) {
			ChatterTime();
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject == playerBuddy) {
			scriptReference.currentNPC = this.gameObject;
			scriptReference.talkRange = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject == playerBuddy) {
			scriptReference.talkRange = false;
		}
	}

	void ChatterTime() {
		if (i < conversationMessages.Length) {
			dialogueText.text = conversationMessages[i];
			clickable = false;
			StartCoroutine(NextMsg());
		} else {
			NPCState(false);
			scriptReference.isTalking = false;
			scriptReference.talkRange = true;
		}
	}

	IEnumerator NextMsg() {
		yield return new WaitForSeconds(.5f);
		i++;
		clickable = true;
	}
}