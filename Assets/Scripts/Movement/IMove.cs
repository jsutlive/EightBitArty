using System.Collections;

public interface IMoveWithCoroutines
{
    IEnumerator WaitForMovement();
    IEnumerator MoveArty();
    void StopMovement();
}