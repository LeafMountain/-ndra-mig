using UnityEngine;
using Assets.Script.Interfaces;

namespace Assets.Script.States
{
	public class PauseState : IStateBase
	{
		private GameStateManager gameStateManager;
		private GameObject canvas;
		private ControllerUI cUI;

		public PauseState (GameStateManager managerRef, GameObject canvasRef, ControllerUI cUIRef)
		{
			Debug.Log("Constructing PauseState");
			gameStateManager = managerRef;
			cUI = cUIRef;

			canvas = canvasRef;

			Time.timeScale = 0;
			ShowIt();
		}
		public void StateUpdate()
		{
			if(Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.Joystick1Button7) || Input.GetKeyUp(KeyCode.Joystick1Button1))
			{
				gameStateManager.SwitchState(new PlayState(gameStateManager, canvas, cUI));
				canvas.transform.GetChild(3).transform.gameObject.SetActive(true);
				canvas.transform.GetChild(4).transform.gameObject.SetActive(false);

			}
		}
		public void ShowIt()
		{
			canvas.transform.GetChild(4).gameObject.SetActive(true);
		}
	}
}