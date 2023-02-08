using UnityEngine;
using System.Collections;

using static UnityEngine.SceneManagement.SceneManager;
using static UnityEngine.SceneManagement.LoadSceneMode;

public class EndSquare : MonoBehaviour
{
    [SerializeField] AudioClip winClip;
    [SerializeField] string nextLevel;
    [SerializeField] string thisLevel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ArtyMover mover = other.GetComponent<ArtyMover>();
            if (mover.HasFoundBattery)
            {
                SFXManager.RequestClip(winClip);
                mover.ArtyWin();
                if(nextLevel!="") StartCoroutine(LoadLevel());
            }

            else
            {
                other.GetComponent<ArtyMover>().SetArtyDirection(Quaternion.Euler(0, -90, 0));
            }
        }
    }

    IEnumerator LoadLevel()
    {
        float time = 0;
        while (time < 2.75f)
        {
            time += Time.deltaTime;
            yield return null;
        }
        LoadSceneAsync(nextLevel, Additive);
        UnloadSceneAsync(GetSceneByName(thisLevel));        
    }
}
