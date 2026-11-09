using UnityEngine;
using UnityEngine.UI;

public class ThrustProgressBar : MonoBehaviour
{
    private Image progressBarImage;
    [SerializeField] private ThrustFuel thrustFuel; // Reference to the ThrustFuel ScriptableObject
    void Start()
    {
        progressBarImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        progressBarImage.fillAmount = thrustFuel.FuelAmount / 100;
    }
}
