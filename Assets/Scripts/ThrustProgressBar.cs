using UnityEngine;
using UnityEngine.UI;

public class ThrustProgressBar : MonoBehaviour
{
    private Image progressBarImage;
    [SerializeField] private GameObject Player; // Reference to the Player object
    void Start()
    {
        progressBarImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        progressBarImage.fillAmount = Player.GetComponent<PlayerMovement>().GetCurrentFuel() / 100;
    }
}
