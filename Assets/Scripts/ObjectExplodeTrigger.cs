using UnityEngine;
using System.Collections;

public class ObjectExplodeTrigger : MonoBehaviour
{
    [SerializeField] GameObject parent;
    ExplosionSquare exploder;

    private void Start()
    {
        exploder = parent.GetComponent<ExplosionSquare>();
    }
    private void OnTriggerEnter(Collider other)
    {        
        if (other.CompareTag("Player"))
        {
            if (other.TryGetComponent(out IPowerup power))
            {
                if (power.HasPowerup() && parent.TryGetComponent(out IExplode explode))
                {
                    exploder.canTrigger = false;
                    StartCoroutine(Explode(explode));
                }
            }            
        }
    }

    IEnumerator Explode(IExplode explode)
    {
        float time = 0;
        while (time < 0.1f)
        {
            time += Time.deltaTime;
            yield return null;
        }
        explode.Explode();
    }
}
