using UnityEngine;
using Assets.Script.Interfaces;

namespace Assets.Script.States
{
	public class MainMenuState : IStateBase
	{
		private GameStateManager gameStateManager;
		private GameObject canvas;
		private ControllerUI cUI;

		public MainMenuState (GameStateManager managerRef, GameObject canvasRef, ControllerUI cUIRef)
		{
			Debug.Log("Constructing MainState");
			gameStateManager = managerRef;
			canvas = canvasRef;
			cUI = cUIRef;
			ShowIt();

		}
		public void StateUpdate()
		{
			if(Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.Joystick1Button1))
			{
				gameStateManager.SwitchState(new BeginState(gameStateManager, canvas, cUI));
				canvas.transform.GetChild(1).gameObject.SetActive(true);
				canvas.transform.GetChild(2).gameObject.SetActive(false);

				cUI.Select(canvas.transform.GetChild(1).gameObject);

			}
		}
		public void ShowIt()
		{
			canvas.transform.GetChild(2).gameObject.SetActive(true);
		}
	}
}
