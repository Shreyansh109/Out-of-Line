using UnityEngine;

[CreateAssetMenu(fileName = "ThrustFuel", menuName = "Scriptable Objects/ThrustFuel")]
public class ThrustFuel : ScriptableObject
{
    private float fuelAmount = 100f;
    public float FuelAmount
    {
        get { return fuelAmount; }
        set { fuelAmount = value; }
    }

    void OnAwake()
    {
        fuelAmount = 100f;
    }

    public void UseFuel()
    {
        if (fuelAmount > 0)
        {
            fuelAmount -= Time.deltaTime*3; // Decrease fuel amount over time
            Debug.Log("Fuel Amount: " + fuelAmount);
            if (fuelAmount < 0)
            {
                fuelAmount = 0; // Ensure fuel amount doesn't go below zero
            }
        }
    }

    public void RefillFuel()
    {
        if (fuelAmount < 100f)
        {
            fuelAmount += Time.deltaTime*3; // Increase fuel amount by the specified amount
        }
    }
}
