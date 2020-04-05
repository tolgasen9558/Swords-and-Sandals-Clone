using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    private float damage;
    private float hitChance;


    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    public void SetHitChance(float hitChance)
    {
        if(hitChance < 0.20 || hitChance > 0.99f)
        {
            Debug.LogWarning("Hit chance is set to: " + hitChance
                + " , is there something wrong?");
        }
        this.hitChance = Mathf.Clamp(hitChance, 0.0f, 1.0f);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(!col.gameObject.CompareTag("Enemy")) return;

        var enemyHealth = col.gameObject.GetComponent<Health>();
        if(enemyHealth)
        {
            if(Random.Range(0.0f, 1.0f) <= hitChance)
            {
                enemyHealth.TakeDamage(damage);
            }
            else
            {
                Debug.Log("MISS!");
            }
        }
    }
}
