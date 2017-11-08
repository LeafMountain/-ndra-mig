//Detta Script är tänkt att sitta på ett GameObject som också har MenuCommands och ControllerUI components. Scriptet behöver att ens GameObject har en Canvas till barn och att allt ligger i rätt ordning 
//bland canvasens barn. Mellan varje State skickas en StateManager, en Canvas och en Controller UI. För bättre hum om State machines eller state managers kolla "learning C# by Developing Games with Unity" en av våra 
//tidiga kurslitteraturer. 

using UnityEngine;
using Assets.Script.States;
using Assets.Script.Interfaces;

public class GameStateManager : MonoBehaviour {

	private IStateBase activeState;
	private ControllerUI cUI;
	private GameObject canvas;
	private AudioManager audioManager;

	private static GameStateManager instanceRef;


	void Awake()
	{
		if(instanceRef == null)
		{
			instanceRef = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	void Start () {
		cUI = GetComponent<ControllerUI>();
		canvas = gameObject.transform.GetChild(0).transform.gameObject;
		audioManager = gameObject.transform.GetChild(1).GetComponent<AudioManager>();
		activeState = new BeginState(this);

		audioManager.PlaySong("Myspals_introSongStart");


	}
	void Update () {

		if(activeState != null)
		{
			activeState.StateUpdate();
		}
	
	}
	public void SwitchState(IStateBase newState)
	{
		activeState = newState;
	}
	public GameObject GetCavnas()
	{
		return canvas;
	}
	public ControllerUI GetControllerUI()
	{
		return cUI;
	}
	public AudioManager GetAudioManager()
	{
		return audioManager;
	}
}
