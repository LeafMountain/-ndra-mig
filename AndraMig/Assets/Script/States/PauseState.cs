using UnityEngine;
using Assets.Script.Interfaces;

namespace Assets.Script.States
{
	public class PauseState : IStateBase
	{
		private GameStateManager gameStateManager;
		private GameObject canvas;
		private ControllerUI cUI;
		private AudioManager audioManager;



		public PauseState (GameStateManager managerRef)
		{
			Debug.Log("Constructing PauseState");
			gameStateManager = managerRef;
			cUI = gameStateManager.GetControllerUI();
			audioManager = gameStateManager.GetAudioManager();
			canvas = gameStateManager.GetCavnas();

			audioManager.PauseMusic();

			Time.timeScale = 0;
			ShowIt();




		}
		public void StateUpdate()
		{
			if(Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.Joystick1Button7) || Input.GetKeyUp(KeyCode.Joystick1Button1))
			{
				gameStateManager.SwitchState(new PlayState(gameStateManager));
				canvas.transform.GetChild(3).transform.gameObject.SetActive(true);
				canvas.transform.GetChild(4).transform.gameObject.SetActive(false);
				canvas.transform.GetChild(5).transform.gameObject.SetActive(false);

			}
			if(Input.GetKeyUp(KeyCode.Joystick1Button0) || Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.Space))
			{
				audioManager.PlaySelect();
			}
		}
		public void ShowIt()
		{
			canvas.transform.GetChild(4).gameObject.SetActive(true);
		}
	}
}