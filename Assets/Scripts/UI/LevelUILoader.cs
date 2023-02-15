using UnityEngine;
using System.Collections.Generic;

public class LevelUILoader : MonoBehaviour
{
    [SerializeField] GameObject levelMenu;
    [SerializeField] GameObject rootMenu;

    public void EnableMenu()
    {
        levelMenu.SetActive(true);
        rootMenu.SetActive(false);
    }

    public void DisableMenu()
    {
        levelMenu.SetActive(false);
        rootMenu.SetActive(true);
    }
}
