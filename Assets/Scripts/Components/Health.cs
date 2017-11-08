using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Health : MonoBehaviour {

    public readonly int maxHealth = 3;
    public int currentHealth;

    public UnityEvent OnDamaged;
    public UnityEvent OnHealed;
    public UnityEvent OnNoHealth;

    void Start(){
        currentHealth = maxHealth;
    }

    public void Damage(int amount) {
        if(amount < 0){
            Debug.LogError("Cant damage negative damage");
            return;
        }

        currentHealth -= amount;

        OnDamaged.Invoke();

        if (currentHealth <= 0){
            currentHealth = 0;
            OnNoHealth.Invoke();
        }
    }

    public void Heal(int amount){
        currentHealth += amount;

        OnHealed.Invoke();
    }
}
