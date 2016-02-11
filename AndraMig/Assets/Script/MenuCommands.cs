//Detta script är en samligns plats för alla knappfunktioner.

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Assets.Script.States;
using UnityEngine.UI;

public class MenuCommands : MonoBehaviour {

	private	AudioManager audioManager;
	private GameStateManager manager;

	private GameObject canvas;
	private GameObject pausePanel;
	private GameObject areUSurePanel;

	private ControllerUI cUI;

	private TextAsset quittingText;
	private TextAsset returnToMainMenuText;


	private bool quitting;

	void Start()
	{
		manager = GetComponent<GameStateManager>();
		canvas = GameObject.Find("Canvas");
		cUI = GetComponent<ControllerUI>();
		audioManager = GetComponent<AudioManager>();

		pausePanel = canvas.transform.GetChild(4).gameObject;
		areUSurePanel = canvas.transform.GetChild(5).gameObject;

		quittingText = Resources.Load("Text/AreYouSure/Quitting") as TextAsset;
		returnToMainMenuText = Resources.Load("Text/AreYouSure/ReturntoMainMenu") as TextAsset;

		quitting = false;
	}

	public void Quit()
	{
		Application.Quit();
	}
	public void NewGame()
	{

		SceneManager.LoadScene("Test_Fielder");
		manager.SwitchState(new PlayState(manager));
		canvas.transform.GetChild(0).gameObject.SetActive(false);
		canvas.transform.GetChild(1).gameObject.SetActive(false);



	}
		
	public void Resume()
	{
		
		manager.SwitchState(new PlayState(manager));
		canvas.transform.GetChild(3).gameObject.SetActive(true);
		pausePanel.SetActive(false);


	}
	public void ReturnToMainMenu()
	{
		areUSurePanel.SetActive(true);
		pausePanel.gameObject.SetActive(false);

		areUSurePanel.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = returnToMainMenuText.ToString();

		cUI.Select(canvas.transform.GetChild(5).GetChild(1).gameObject);
	}
	public void QuitGame()
	{
		quitting = true;
		areUSurePanel.SetActive(true);
		pausePanel.SetActive(false);

		areUSurePanel.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = quittingText.ToString();


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

		areUSurePanel.gameObject.SetActive(false);
		pausePanel.gameObject.SetActive(true);

		quitting = false;

		cUI.Select(canvas.transform.GetChild(4).GetChild(1).gameObject);
	}
}
