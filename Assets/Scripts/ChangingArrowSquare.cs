using System.Collections;
using UnityEngine;

public class ChangingArrowSquare : MonoBehaviour
{
    [SerializeField] bool clockwise = true;
    Quaternion addRotation;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<ArtyMover>().SetArtyDirection(transform);
        }
    }

    private void Start()
    {
        if (!clockwise)
        {
            addRotation = Quaternion.Euler(0, -90, 0);
        }
        else
        {
            addRotation = Quaternion.Euler(0, 90, 0);
        }
        StartCoroutine(RotateSquare());
    }

    IEnumerator RotateSquare()
    {
        float time = 0;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = transform.rotation * addRotation;
        while (time < 0.25f)
        {
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, time / 0.25f);
            time += Time.deltaTime;
            yield return null;
        }
        transform.rotation = endRotation;
        StartCoroutine(WaitForMovement());
    }
    IEnumerator WaitForMovement()
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine(RotateSquare());
    }
}
