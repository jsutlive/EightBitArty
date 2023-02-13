using UnityEngine;

public class StartSquare : MonoBehaviour
{
    private bool playerHasLeft;

    private void OnTriggerExit(Collider other)
    {
        playerHasLeft = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!playerHasLeft) return;
        if (other.TryGetComponent(out IRotateWithCoroutines rotater))
        {
            rotater.SetDirection(Quaternion.Euler(0, 90, 0));
        }
    }
}
