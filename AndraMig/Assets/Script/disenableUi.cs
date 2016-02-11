using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class disenableUi : MonoBehaviour
{
    public Canvas canvas;
    public Text scoreText;
    public Text livesText;
    public Image[] livesImg;

    public int point;
    public int buddyHealth;
   
    public void Start ()
    {
        canvas.enabled = false;
        livesImg = GameObject.Find("Lives").GetComponentsInChildren<Image>();
        foreach (Image liv in livesImg)
        {
            buddyHealth++;
        }
    }

    public void TurnItOn ()
    {
        canvas.enabled = true;
    }

    public void ShutItOff ()
    {
        canvas.enabled = false;
    }

    public void Update()
    {
        Debug.Log(buddyHealth.ToString());
        if (canvas.enabled)
        {
            scoreText.text = "score: " + point.ToString();
            livesText.text = "lives: " + livesImg;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            canvas.enabled = !canvas.enabled;
        }
    }
}
