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
        if (other.CompareTag("Player"))
        {
            other.GetComponent<ArtyMover>().SetArtyDirection(Quaternion.Euler(0, 90, 0));
        }
    }
}
