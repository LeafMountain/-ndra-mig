using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class disenableUi : MonoBehaviour
{
    public Canvas canvas;
    public Text scoreText;
    public Text livesText;

    public int point;
   
    public void Start ()
    {
        canvas.enabled = false;
    }

    public void TurnItOn ()
    {
        canvas.enabled = true;
    }

    public void ShutItOff ()
    {
        canvas.enabled = false;
    }

    public void Update ()
    {
        if (canvas.enabled)
        {
            scoreText.text = "score: " + point.ToString();
            livesText.text = "lives: ";
        }
    }
 

	
}
