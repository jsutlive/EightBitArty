using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSquare : MonoBehaviour
{
    [SerializeField] private AudioClip explosionClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<ArtyMover>().StopArtyMovement();
            SFXManager.RequestClip(explosionClip);
        }
    }
}
