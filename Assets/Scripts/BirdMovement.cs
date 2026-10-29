
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    float speed = 1f;
    public float destroyMargin = 0.1f;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Move to the right
        transform.position +=
            Vector3.right * speed * Time.deltaTime;

        // Check whether the bird has passed the right edge
        Vector3 viewPosition =
            mainCamera.WorldToViewportPoint(transform.position);

        if (viewPosition.x > 1f + destroyMargin)
        {
            Destroy(gameObject);
        }
    }
}
