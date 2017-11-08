using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {
    public int value = 1;

    Collector collector;

    void OnTriggerStay (Collider col) {
        if(collector == null){
            collector = col.GetComponent<Collector>();
        } else if(collector){
            transform.position = Vector3.MoveTowards(transform.position, collector.transform.position, Time.deltaTime * 25);
            if (transform.position == collector.transform.position){
                collector.Collected(value);
                Destroy(gameObject);
            }
        }
    }
}
