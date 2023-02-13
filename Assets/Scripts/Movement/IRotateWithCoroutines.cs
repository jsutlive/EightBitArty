using System.Collections;
using UnityEngine;

public interface IRotateWithCoroutines
{
    IEnumerator Rotate();
    void SetDirection(Transform direction);
    void SetDirection(Quaternion direction);
}