using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float stepSize = 0.75f;

    void Start()
    {
        
    }

    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(Vector2.left * stepSize);
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(Vector2.right * stepSize);
        }
    }
}           
