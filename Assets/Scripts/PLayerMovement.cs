using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private InputAction moveAction;
    private Vector2 inputVector;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void OnMove(InputValue value)
    {
        inputVector = value.Get<Vector2>();
        // Handle movement logic here using inputVector
    }

    private void Move()
    {
        rb.linearVelocityX = inputVector.x * 5f; // Adjust speed as needed
    }
}
