using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField]
    private int maxHealth = 50;
    private int currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log(gameObject.name + " took " + damage + " damage");
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
        else
        {
            Debug.Log("Current health of " + gameObject.name + ": " + currentHealth);
        }
    }

    private void Die()
    {
        Debug.Log(gameObject.name + " faced certain death");
    }
}
