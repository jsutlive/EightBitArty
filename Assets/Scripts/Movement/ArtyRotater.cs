using UnityEngine;
using System.Collections;

public class ArtyRotater : MonoBehaviour, IRotateWithCoroutines
{
    [SerializeField] float artyRotateTime;
    private Quaternion targetRotation;

    public IEnumerator Rotate()
    {
        float time = 0;
        Quaternion startRotation = transform.rotation;
        while (time < artyRotateTime)
        {
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, time / artyRotateTime);
            time += Time.deltaTime;
            yield return null;
        }
        transform.rotation = targetRotation;
    }

    public void SetDirection(Transform arrowDirectionTransform)
    {
        float rotation = arrowDirectionTransform.eulerAngles.y;
        if (rotation % 90 != 0)
        {
            rotation = Mathf.Round(rotation / 90f);
            rotation *= 90f;
        }
        targetRotation = Quaternion.Euler(0, rotation, 0);

    }

    public void SetDirection(Quaternion rotation)
    {
        targetRotation = rotation;
    }
}
