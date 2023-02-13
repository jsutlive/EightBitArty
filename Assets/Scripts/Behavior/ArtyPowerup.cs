using UnityEngine;
using System.Collections;

public class ArtyPowerup : MonoBehaviour, IPowerup
{
    private bool hasPowerup;
    private bool hasBattery;

    public bool HasBattery() => hasBattery;
    public bool HasPowerup() => hasPowerup;

    public void SetBattery(bool state) => hasBattery = state;
    public void SetPowerup(bool state) => hasPowerup = state;   
}
