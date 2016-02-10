using UnityEngine;
using System.Collections;

public class Point : MonoBehaviour {

    public disenableUi uiScript;

    //private bool taken;
    private Vector3 player;

    public void Start ()
    {
        uiScript = GameObject.Find("Buddy").GetComponent<disenableUi>();
        //taken = false;
    }

	//void Update()
	//{
	//	//transform.rotation = transform.rotation * Quaternion.Euler(Vector3.up);
 //       if (taken)
 //       {
 //           transform.position = Vector3.MoveTowards(transform.position, player, Time.deltaTime * 10);
 //           if (transform.position == player)
 //               Destroy(gameObject);
 //       }
	//}
	
	void OnTriggerEnter (Collider col)
	{
		if(col.gameObject.tag == "Player")
		{
            player = col.GetComponent<Collider>().bounds.center;
            ////taken = true;
            //uiScript.point++;
            uiScript.SendMessage("TurnItOn");
            uiScript.Invoke("ShutItOff", 5);

            transform.position = Vector3.MoveTowards(transform.position, player, Time.deltaTime * 10);
            if (transform.position == player)
                Destroy(gameObject);
            uiScript.point++;

        }
	}
    //void OnTrigger(Collider col)
    //{
    //    if (col.gameObject.tag == "Player")
    //    {
    //        uiScript.SendMessage("TurnItOn");
    //        uiScript.Invoke("ShutItOff", 5);
    //    }
    //}
}
