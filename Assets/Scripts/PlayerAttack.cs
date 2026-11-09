using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{

    [Header("Animation")]
    [SerializeField] private Animator animator;

    [Header("Audio")]
    AudioSource audioSource;
    [SerializeField] AudioClip swordSwingSound;
    [SerializeField] AudioClip swordHitSound;
    bool isEnemyInRange = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");
        if (isEnemyInRange && !animator.GetCurrentAnimatorStateInfo(0).IsName("Flying"))
        {
            audioSource.clip =  swordHitSound;
            audioSource.Play();
            
        }
        else
        {
            if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Flying"))
            {
                audioSource.clip = swordSwingSound;
                audioSource.Play();
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            isEnemyInRange = true;
            
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            isEnemyInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            isEnemyInRange = false;
        }
    }
}
