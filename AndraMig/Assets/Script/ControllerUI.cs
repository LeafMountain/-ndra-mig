//Detta script gör en lista på knappar som man sedan kan navigera med en kontroll.

using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class ControllerUI : MonoBehaviour {

	private static List<Button> buttonList;
	private int index = 0;

	void Start () {

		buttonList = new List<Button>();
	}
	public void Select(GameObject buttonLists)
	{
		if(buttonList.Count > 0)
		{
		buttonList.Clear();
		}
		for(int i = 0; i < buttonLists.transform.childCount; i++)
		{
			buttonList.Add(buttonLists.transform.GetChild(i).gameObject.GetComponent<Button>());
		}

		buttonList[index].Select();
	}

}
