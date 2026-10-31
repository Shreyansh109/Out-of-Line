using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    Vector2 initialPosition;
    int direction = 1;
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, direction * Time.deltaTime * 2f, 0);
        if (transform.position.y > initialPosition.y + 5f)
        {
            direction = -1;
        }
        else if (transform.position.y < initialPosition.y - 5f)
        {
            direction = 1;
        }
    }
}
