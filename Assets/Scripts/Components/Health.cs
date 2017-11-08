using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int health = 3;

    private Renderer rend;
    private Color originalColor;

    public bool damage;

    void Awake() {
        rend = GetComponentInChildren<Renderer>();
        originalColor = rend.material.color;
    }

    void Update(){
        if(damage){
            Damage(1);
            damage = false;
        }
    }

    public void Damage(int damage) {
        health -= damage;
        rend.material.color = Color.red;

        if (health <= 0){
            Destroy(gameObject);
        }

        Invoke("OriginalColor", 1f);
    }

    void OriginalColor()
    {
        rend.material.color = originalColor;
    }
    
}
