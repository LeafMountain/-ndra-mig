using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int health;

    private Renderer rend;
    private Color originalColor;

    public disenableUi dUI;

    void Awake()
    {
        rend = GetComponentInChildren<Renderer>();
        originalColor = rend.material.color;
    }

    public void Damaged(int damage)
    {
        health -= damage;
        rend.material.color = Color.red;

        if (health <= 0)
            Destroy(gameObject);
        Invoke("OriginalColor", 0.2f);
    }

    void OriginalColor()
    {
        rend.material.color = originalColor;
    }
    
}
