using UnityEngine;
using System.Collections;

public class EndSquare : MonoBehaviour
{
    [SerializeField] AudioSource source;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ArtyStateHandler handler = other.GetComponent<ArtyStateHandler>();
            ArtyPowerup powerup = other.GetComponent<ArtyPowerup>();
            if (powerup.HasBattery())
            {
                source.Play();
                handler.Win();
            }

        }        
        if (other.TryGetComponent(out IRotateWithCoroutines rotater))
        {
            rotater.SetDirection(transform);
        }
    }    
}
