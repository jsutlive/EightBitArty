using System.Collections;
using UnityEngine;

public class ArtyMover : MonoBehaviour, IMoveWithCoroutines
{
    [SerializeField] private float artyWaitTime;
    [SerializeField] private float artyMoveTime;
    [SerializeField] private AudioClip artyMoveClip;
    [SerializeField] private AudioSource artyAudio;
    private bool artyCanMove = true;
    private int moveCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForMovement());
    }  

    public IEnumerator WaitForMovement()
    {
        yield return new WaitForSeconds(artyWaitTime);
        artyAudio.clip = artyMoveClip;
        artyAudio.Play();
        StartCoroutine(MoveArty());
    }   

    public IEnumerator MoveArty()
    {
        float time = 0;
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = (3.0f * transform.right) + startPosition;
        while (time < artyMoveTime)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / artyMoveTime);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        moveCount++;
        if (artyCanMove)
        {
            StartCoroutine(GetComponent<IRotateWithCoroutines>().Rotate());
            StartCoroutine(WaitForMovement());
        }
    }

    public void StopMovement()
    {
        artyCanMove = false;
    }
}
