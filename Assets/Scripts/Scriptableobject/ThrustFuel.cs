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
}
