using UnityEngine;
using System.Collections;

public class Water_ripples : MonoBehaviour
{

    Projector proj;

    void Awake()
    {
        proj = GetComponent<Projector>();
    }
    void Update()
    {
        proj.fieldOfView = Mathf.Lerp(proj.fieldOfView, 100, Time.deltaTime);
    }
}
