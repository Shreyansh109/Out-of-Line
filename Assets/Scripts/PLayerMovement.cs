using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerMovement : MonoBehaviour
{
    private InputAction moveAction;
    private Vector2 inputVector;
    private Rigidbody2D rb;
    private Animator animator;
    private BoxCollider2D boxCollider;
    private AudioSource audioSource;
    bool isGrounded = false;
    bool isJumping = false;
    private bool isJetActive = false;
    private float currentJetFuel;
    //public InputActionReference flyAction; // Reference to the fly action

    [Header("Attack Settings")]
    PlayerAttack playerAttack;

    [Header("Flying Settings")]
    [SerializeField] private float flyForce = 8f;
    [SerializeField] private float maxFlySpeed = 8f;
    [SerializeField] private ParticleSystem jetSmoke;
    [SerializeField] private ThrustFuel thrustFuel; // Reference to the ThrustFuel ScriptableObject
    InputAction jetAction;

    [Header("Audio Settings")]
    [SerializeField] private AudioSource audioSourceSFX;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip landSound;
    [SerializeField] private AudioClip jetSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
        jetAction = GetComponent<PlayerInput>().actions["Jet"];
        playerAttack = GetComponentInChildren<PlayerAttack>();
        currentJetFuel = thrustFuel.FuelAmount;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        //Flying();
        isGrounded = boxCollider.IsTouchingLayers(LayerMask.GetMask("Platform")) || boxCollider.IsTouchingLayers(LayerMask.GetMask("MovingPlatform"));
    }

    void FixedUpdate()
    {
        Flying();
    }

    void OnMove(InputValue value)
    {
        inputVector = value.Get<Vector2>();
        // Handle movement logic here using inputVector
    }

    private void Move()
    {   
        audioSource.volume = Mathf.Abs(inputVector.x)*System.Convert.ToSingle(isGrounded); // Adjust volume based on movement and grounded state
        if (inputVector.x > 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1); // Face right
            animator.SetBool("isRunning", !jetAction.IsPressed());
        }
        else if (inputVector.x < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1); // Face left
            animator.SetBool("isRunning", !jetAction.IsPressed());
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        rb.linearVelocityX = inputVector.x * 5f; // Adjust speed as needed
    }
    
    void Flying()
    {
        isJetActive = jetAction.IsPressed();
        //isJetActive = jetAction.action.IsPressed(); // Check if the jet action is pressed
        if (jetAction.IsPressed() && rb.linearVelocity.y < maxFlySpeed && currentJetFuel > 0f)
        {
            //print("Jetpack: " + isJetActive);
            jetSmoke.Play();
            animator.SetBool("isFlying", true);
            rb.AddForce(new Vector2(0f, flyForce), ForceMode2D.Impulse); // Apply upward force for flying
            UseFuel(); // Decrease fuel level when flying
            if (!audioSourceSFX.isPlaying)
            {
                audioSourceSFX.clip = jetSound; // Play jet sound effect
                audioSourceSFX.volume = 0.3f; // Set volume for jet sound effect
                audioSourceSFX.Play();
            }
        }
        else if(!jetAction.IsPressed() || currentJetFuel <= 0f)
        {
            jetSmoke.Stop();
            RefillFuel(); // Refill fuel when not flying
            animator.SetBool("isFlying", false);
            if (audioSourceSFX.clip == jetSound && audioSourceSFX.isPlaying)
            {
                audioSourceSFX.Stop(); // Stop jet sound effect when not flying
                audioSourceSFX.volume = 1f; // Reset volume for other sound effects
            }
        }

    }

    void OnJump(InputValue value)
    {
        if (value.isPressed && isGrounded)
        {
            rb.AddForce(new Vector2(0f, 500f), ForceMode2D.Force); // Apply jump force
            animator.SetTrigger("isJumping");
            audioSourceSFX.clip = jumpSound; // Play jump sound effect
            audioSourceSFX.Play();
            isJumping = true;
        }
    }
    //LayerMask.LayerToName(collision.gameObject.layer) == "Platform"

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = boxCollider.IsTouchingLayers(LayerMask.GetMask("Platform")) || boxCollider.IsTouchingLayers(LayerMask.GetMask("MovingPlatform"));
        if(isGrounded)
        {
            print("Collided with Ground");
        }
        if ((LayerMask.LayerToName(collision.gameObject.layer) == "Platform" || LayerMask.LayerToName(collision.gameObject.layer) == "MovingPlatform") && isJumping)
        {
            audioSourceSFX.clip = landSound; // Play land sound effect
            audioSourceSFX.Play();
            isJumping = false;
        }
        if (LayerMask.LayerToName(collision.gameObject.layer) == "MovingPlatform" && isGrounded)
        {
            print("Collided with Moving Platform");
            transform.SetParent(collision.transform); // Set the player as a child of the moving platform
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "MovingPlatform" && isJumping == false)
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "MovingPlatform")
        {
            transform.SetParent(null);
        }
    }

    void OnAttack(InputValue value)
    {
        if (value.isPressed)
        {
            playerAttack.Attack();
        }
    }

    public void UseFuel()
    {
        if (currentJetFuel > 0)
        {
            currentJetFuel -= Time.deltaTime*30; // Decrease fuel amount over time
            if (currentJetFuel < 0)
            {
                currentJetFuel = 0; // Ensure fuel amount doesn't go below zero
            }
        }
    }
    public void RefillFuel()
    {
        if (currentJetFuel < 100f)
        {
            currentJetFuel += Time.deltaTime*3; // Increase fuel amount by the specified amount
        }
    }

    public float GetCurrentFuel()
    {
        return currentJetFuel; // Return the current fuel amount
    }
}
