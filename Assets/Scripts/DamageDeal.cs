using UnityEngine;

public class DamageDeal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Apply Damage");
        }
    }
}
