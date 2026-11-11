using UnityEngine;

public class DisappearingTile : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    
    void Update()
    {
        transparencyCycle();
    }

    private void transparencyCycle()
    {
        float alpha = (Mathf.Sin(Time.time) + 1f) / 2f;

        Color color = spriteRenderer.color;
        color.a = alpha>0.5f ? 1f : 0f; // Set alpha to 1 if greater than 0.5, else set to 0
        boxCollider.enabled = color.a > 0f; // Enable/disable collider based on transparency
        spriteRenderer.color = color;
    }
}
