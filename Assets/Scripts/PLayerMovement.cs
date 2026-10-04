using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{
    private InputAction moveAction;
    private Vector2 inputVector;
    private Rigidbody2D rb;
    private Animator animator;
    private BoxCollider2D boxCollider;
    bool isJumping = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        isJumping = !boxCollider.IsTouchingLayers(LayerMask.GetMask("Platform"));
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

    void OnJump(InputValue value)
    {
        if (value.isPressed && !isJumping)
        {
            rb.linearVelocityY = 11f; // Adjust jump force as needed
            animator.SetTrigger("isJumping");
        }
        else if (!value.isPressed)
        {
            //rb.linearVelocityY = 1f; // Stop jumping when the button is released
        }
    }

    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (boxCollider.IsTouchingLayers(LayerMask.GetMask("Platform")))
    //     {
    //         isJumping = false;
    //     }
    // }//LayerMask.LayerToName(collision.gameObject.layer) == "Platform"
    // void OnCollisionStay2D(Collision2D collision)
    // {
    //     if (boxCollider.IsTouchingLayers(LayerMask.GetMask("Platform")))
    //     {
    //         isJumping = false;
    //     }
    // }
    // void OnCollisionExit2D(Collision2D collision)
    // {
    //     if (boxCollider.IsTouchingLayers(LayerMask.GetMask("Platform")))
    //     {
    //         isJumping = true;
    //     }
    // }
}
