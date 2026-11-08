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
        if (audioSource == null)
        {
            print("AudioSource component is missing!");
        }
        animator.SetTrigger("Attack");
        if (isEnemyInRange)
        {
            audioSource.clip =  swordHitSound;
            
        }
        else
        {
            audioSource.clip = swordSwingSound;
        }
        audioSource.Play();
    }

    // void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Enemy"))
    //     {
    //         isEnemyInRange = true;
    //         print("Enemy in range");
    //     }
    // }
    // void OnTriggerStay(Collider other)
    // {
    //     if (other.CompareTag("Enemy"))
    //     {
    //         isEnemyInRange = true;
    //         print("Enemy in range");
    //     }
    // }

    // void OnTriggerExit(Collider other)
    // {
    //     if (other.CompareTag("Enemy"))
    //     {
    //         isEnemyInRange = false;
    //         print("Enemy out of range");
    //     }
    // }
}
