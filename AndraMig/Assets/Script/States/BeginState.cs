using UnityEngine;
using UnityEngine.UI;
using Assets.Script.Interfaces;

namespace Assets.Script.States
{
	public class BeginState : IStateBase
	{
		private GameStateManager gameStateManager;
		private GameObject canvas;
		private ControllerUI cUI;
		private AudioManager audioManager;
		private GameObject gameBrain;


		public BeginState (GameStateManager managerRef)
		{
			Debug.Log("Constructing BeginState");
			gameStateManager = managerRef;
			cUI = gameStateManager.GetControllerUI();
			canvas = gameStateManager.GetCavnas();
			audioManager = gameStateManager.GetAudioManager();

			ShowIt();



		

		}
		public void StateUpdate()
		{
			if(Input.GetKeyUp(KeyCode.Joystick1Button7) || Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.Space))
			{
				gameStateManager.SwitchState(new MainMenuState(gameStateManager));
				canvas.transform.GetChild(1).transform.gameObject.SetActive(false);

				audioManager.PlaySelect();

				cUI.Select(canvas.transform.GetChild(2).GetChild(0).gameObject);
			}
		}
		public void ShowIt()
		{
			canvas.transform.GetChild(1).gameObject.SetActive(true);
			canvas.transform.GetChild(0).gameObject.SetActive(true);
		}
	
	}
}

