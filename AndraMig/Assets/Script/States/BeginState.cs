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


		public BeginState (GameStateManager managerRef, GameObject canvasRef, ControllerUI cUIRef)
		{
			Debug.Log("Constructing BeginState");
			gameStateManager = managerRef;
			cUI = cUIRef;
			canvas = canvasRef;
			ShowIt();
		}
		public void StateUpdate()
		{
			if(Input.GetKeyUp(KeyCode.Joystick1Button7) || Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.Space))
			{
				gameStateManager.SwitchState(new MainMenuState(gameStateManager, canvas, cUI));
				canvas.transform.GetChild(1).transform.gameObject.SetActive(false);


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

