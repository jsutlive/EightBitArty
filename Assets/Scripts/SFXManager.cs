using System;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] AudioSource SFX;
    private static Action<AudioClip> OnClipPlayRequest;

    private void OnEnable()
    {
        OnClipPlayRequest += PlayClip;
    }

    private void OnDisable()
    {
        OnClipPlayRequest -= PlayClip;
    }

    private void PlayClip(AudioClip clip)
    {
        SFX.clip = clip;
        SFX.Play();
    }

    public static void RequestClip(AudioClip clip) => OnClipPlayRequest?.Invoke(clip);
}
