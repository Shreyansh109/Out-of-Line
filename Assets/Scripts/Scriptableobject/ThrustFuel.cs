using UnityEngine;

[CreateAssetMenu(fileName = "ThrustFuel", menuName = "Scriptable Objects/ThrustFuel")]
public class ThrustFuel : ScriptableObject
{
    private float fuelAmount;
    public float FuelAmount
    {
        get { return fuelAmount; }
        set { fuelAmount = value; }
    }
}
