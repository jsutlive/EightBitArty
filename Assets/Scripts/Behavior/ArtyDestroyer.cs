using UnityEngine;
using System.Collections;

public class ArtyDestroyer : MonoBehaviour, IExplode
{
    [SerializeField] GameObject artyMesh;
    [SerializeField] GameObject artyBoomParticles;
    public bool ArtyDead { get; private set; }

    public void Explode()
    {
        GetComponent<IMoveWithCoroutines>().StopMovement();
        artyMesh.SetActive(false);
        artyBoomParticles.SetActive(true);
    }  
}
