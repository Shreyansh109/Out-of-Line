using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnAttack(InputValue value)
    {
        if (value.isPressed)
        {
            animator.SetTrigger("Attack");
        }
    }
}
