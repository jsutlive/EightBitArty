using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtyMover : MonoBehaviour
{
    public Vector2 artyDirection;
    [SerializeField] private float artyWaitTime;
    [SerializeField] private float artyMoveTime;
    [SerializeField] private AudioClip artyMoveClip;
    [SerializeField] GameObject artyMesh;
    [SerializeField] GameObject artyBoomParticles;
    private bool artyDead;
    Quaternion targetRotation;
    public bool HasFoundBattery { get; private set; }

    public void FindBattery() => HasFoundBattery = true;

    public void SetArtyDirection(Transform arrowDirectionTransform)
    {
        float rotation = arrowDirectionTransform.eulerAngles.y;
        if (rotation % 90 != 0)
        {
            rotation = Mathf.Round(rotation / 90f);
            rotation *= 90f;
        }
        targetRotation = Quaternion.Euler(0, rotation, 0);      

    }

    public void SetArtyDirection(Quaternion rotation)
    {
        targetRotation = rotation;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForMovement());
    }  

    IEnumerator WaitForMovement()
    {
        yield return new WaitForSeconds(artyWaitTime);
        SFXManager.RequestClip(artyMoveClip);
        StartCoroutine(MoveArty());
    }

    IEnumerator RotateArty(Quaternion endRotation)
    {
        float time = 0;
        Quaternion startRotation = transform.rotation;
        while (time < artyMoveTime)
        {
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, time / artyMoveTime);
            time += Time.deltaTime;
            yield return null;
        }
        transform.rotation = endRotation;
    }

    IEnumerator MoveArty()
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
        if (!artyDead)
        {
            StartCoroutine(RotateArty(targetRotation));
            StartCoroutine(WaitForMovement());
        }
    }

    public void StopArtyMovement()
    {
        artyDead = true;
        artyMesh.SetActive(false);
        artyBoomParticles.SetActive(true);
    }

    public void ArtyWin()
    {
        artyDead = true;
    }
}
