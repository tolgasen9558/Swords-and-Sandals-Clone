using UnityEngine;

public class TakeHit : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
                
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(this.gameObject.name + " collided with " + col.gameObject.name);
    }
}
