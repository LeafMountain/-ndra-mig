using UnityEngine;
using Assets.Script.Interfaces;

namespace Assets.Script.States
{
	public class MainMenuState : IStateBase
	{
		private GameStateManager gameStateManager;
		private GameObject canvas;
		private ControllerUI cUI;
		private AudioManager audioManager;

		public MainMenuState (GameStateManager managerRef)
		{
			Debug.Log("Constructing MainState");
			gameStateManager = managerRef;
			canvas = gameStateManager.GetCavnas();
			cUI = gameStateManager.GetControllerUI();
			audioManager = gameStateManager.GetAudioManager();

			ShowIt();

		}
		public void StateUpdate()
		{
			if(Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.Joystick1Button1))
			{
				gameStateManager.SwitchState(new BeginState(gameStateManager));
				canvas.transform.GetChild(1).gameObject.SetActive(true);
				canvas.transform.GetChild(2).gameObject.SetActive(false);

				audioManager.PlayPause();

				cUI.Select(canvas.transform.GetChild(1).gameObject);
			}
			if(Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
			{
				audioManager.PlayMoveJoyStickSound();
			}
		}
		public void ShowIt()
		{
			canvas.transform.GetChild(2).gameObject.SetActive(true);
		}
	}
}
