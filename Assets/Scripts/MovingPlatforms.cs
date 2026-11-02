using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    Vector2 initialPosition;
    int direction = 1;
    [SerializeField] bool vertical = true;
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(vertical ? 0 : direction * Time.deltaTime * 2f, vertical ? direction * Time.deltaTime * 2f : 0, 0);
        if (transform.position.y > initialPosition.y + 5f  && vertical)
        {
            direction = -1;
        }
        else if (transform.position.y < initialPosition.y - 5f && vertical)
        {
            direction = 1;
        }
        if (transform.position.x > initialPosition.x + 5f && !vertical)
        {
            direction = -1;
        }
        else if (transform.position.x < initialPosition.x - 5f && !vertical)
        {
            direction = 1;
        }
    }
}
