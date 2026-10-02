using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{
    private InputAction moveAction;
    private Vector2 inputVector;
    private Rigidbody2D rb;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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
        if (inputVector.x > 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1); // Face right
            animator.SetBool("isRunning", true);
        }
        else if (inputVector.x < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1); // Face left
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        rb.linearVelocityX = inputVector.x * 5f; // Adjust speed as needed
    }
}
