using UnityEngine;

public class Health : MonoBehaviour
{
    public void TakeDamage(float damage)
    {
        Debug.Log(gameObject.name + " took " + damage + " damage");
    }
}
