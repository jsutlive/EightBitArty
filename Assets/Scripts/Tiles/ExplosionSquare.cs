using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSquare : MonoBehaviour
{
    [SerializeField] private AudioClip explosionClip;
    public bool canTrigger = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IExplode explode) && canTrigger)
        {
            foreach(BoxCollider collider in GetComponentsInChildren<BoxCollider>()) { collider.enabled = false; }
            explode.Explode();
            SFXManager.RequestClip(explosionClip);
        }
    }
}
