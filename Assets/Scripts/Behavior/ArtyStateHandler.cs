using UnityEngine;
using System.Collections;

public class ArtyStateHandler : MonoBehaviour
{
    public void Win()
    {
        GetComponent<IMoveWithCoroutines>().StopMovement();
        GameManager.LoadNextLevel();
    }

    public void Lose()
    {
        GetComponent<IMoveWithCoroutines>().StopMovement();
    }
    
}
