//Detta script är en samligns plats för alla knappfunktioner.

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Assets.Script.States;

public class MenuCommands : MonoBehaviour {

	private GameStateManager manager;
	private GameObject canvas;
	private ControllerUI cUI;

	private bool quitting;

	void Start()
	{
		manager = GetComponent<GameStateManager>();
		canvas = GameObject.Find("Canvas");
		cUI = GetComponent<ControllerUI>();

		quitting = false;
	}

	public void Quit()
	{
		Application.Quit();
	}
	public void NewGame()
	{
		SceneManager.LoadScene("AxelTest");
		manager.SwitchState(new PlayState(manager, canvas, cUI));
		canvas.transform.GetChild(0).gameObject.SetActive(false);
		canvas.transform.GetChild(2).gameObject.SetActive(false);

	}
		
	public void Resume()
	{
		manager.SwitchState(new PlayState(manager, canvas, cUI));
		canvas.transform.GetChild(3).gameObject.SetActive(true);
		canvas.transform.GetChild(4).gameObject.SetActive(false);
	}
	public void ReturnToMainMenu()
	{
		canvas.transform.GetChild(5).gameObject.SetActive(true);
		canvas.transform.GetChild(4).gameObject.SetActive(false);

		cUI.Select(canvas.transform.GetChild(5).GetChild(1).gameObject);
	}
	public void QuitGame()
	{
		quitting = true;
		canvas.transform.GetChild(5).gameObject.SetActive(true);
		canvas.transform.GetChild(4).gameObject.SetActive(false);

		cUI.Select(canvas.transform.GetChild(5).GetChild(1).gameObject);
	}
	public void Yes()
	{
		if(quitting == false)
		{
			SceneManager.LoadScene("MainMenu_Axel");
			Destroy(gameObject);
		}
		else
		{
			Application.Quit();
		}	
	}
	public void No()
	{
		canvas.transform.GetChild(5).gameObject.SetActive(false);
		canvas.transform.GetChild(4).gameObject.SetActive(true);

		cUI.Select(canvas.transform.GetChild(4).GetChild(1).gameObject);
	}
}
