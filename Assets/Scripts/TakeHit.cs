using UnityEngine;

public class TakeHit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(this.gameObject.name + " collided with " + col.gameObject.name);
    }
}
