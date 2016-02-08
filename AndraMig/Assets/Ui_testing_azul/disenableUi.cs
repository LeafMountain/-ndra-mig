using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class disenableUi : MonoBehaviour
{
    public Canvas canvas;
    public Text scoreText;

    public int point;
   
    public void Start ()
    {
        canvas.enabled = false;
    }

    public void TurnItOn ()
    {
        point++;
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
        }
    }
 

	
}
