using UnityEngine;

public class ArrowSquare : MonoBehaviour
{
    [SerializeField] bool staticArrow;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IRotateWithCoroutines rotater))
        {
            rotater.SetDirection(transform);
        }
    }

    public void Rotate(int multiplier = 1)
    {
        if (staticArrow) return;
        transform.Rotate(0, 90 * multiplier, 0);
    }
}
