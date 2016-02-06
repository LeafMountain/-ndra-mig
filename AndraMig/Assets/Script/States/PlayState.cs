using UnityEngine;
using Assets.Script.Interfaces;

namespace Assets.Script.States
{
	public class PlayState : IStateBase
	{
		private GameStateManager gameStateManager;
		private GameObject canvas;
		private ControllerUI cUI;
		private AudioManager audioManager;

		public PlayState (GameStateManager managerRef)
		{
			Debug.Log("Constructing PlayState");
			gameStateManager = managerRef;
			canvas = gameStateManager.GetCavnas();
			cUI = gameStateManager.GetControllerUI();
			audioManager = gameStateManager.GetAudioManager();

			ShowIt();

			audioManager.PlaySong("Myspals_field");

			Time.timeScale = 1;
		}
		public void StateUpdate()
		{
			if(Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.Joystick1Button7))
			{
				gameStateManager.SwitchState(new PauseState(gameStateManager));
				canvas.transform.GetChild(3).transform.gameObject.SetActive(false);

				cUI.Select(canvas.transform.GetChild(4).GetChild(1).gameObject);
			}

		}
		public void ShowIt()
		{
			canvas.transform.GetChild(3).transform.gameObject.SetActive(true);
		}
	}
}