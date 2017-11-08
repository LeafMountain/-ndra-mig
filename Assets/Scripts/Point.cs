using UnityEngine;
using System.Collections;

public class Point : MonoBehaviour {

    public disenableUi uiScript;

    private Vector3 player;

    public void Start ()
    {
        uiScript = GameObject.Find("Buddy").GetComponent<disenableUi>();
    }
    
	void OnTriggerStay (Collider col)
	{
		if(col.gameObject.tag == "Player")
		{
            player = col.GetComponent<Collider>().bounds.center;

            transform.position = Vector3.MoveTowards(transform.position, player, Time.deltaTime * 25);
            if (transform.position == player)
                Destroy(gameObject);

        }
	}
    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            uiScript.SendMessage("TurnItOn");
            uiScript.Invoke("ShutItOff", 5);

            uiScript.point++;
        }
    }
}
