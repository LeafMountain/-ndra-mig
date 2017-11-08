using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour
{

    public GameObject waterInteraction;
    public float rippleFrequency;
    public float rippleSize;

    private GameObject interaction;
    private Ray hitPoint;
    private RaycastHit hit;


    void OnTriggerStay(Collider col)
    {
        hitPoint = new Ray(col.transform.position + Vector3.up, Vector3.down);

        if (Physics.Raycast(hitPoint, out hit, Mathf.Infinity) && !IsInvoking("Ripple"))
        {
            Invoke("Ripple", rippleFrequency);
        }
    }

    void Ripple()
    {
        interaction = Instantiate(waterInteraction, hit.point, Quaternion.identity) as GameObject;
        Destroy(interaction, rippleSize);
    }
}
