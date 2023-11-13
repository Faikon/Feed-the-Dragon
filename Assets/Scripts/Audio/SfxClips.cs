using System;
using UnityEngine;

public class SfxClips : MonoBehaviour
{
    [SerializeField] private AudioSource _sfxSource;
    [SerializeField] private AudioClip _getFood;
    [SerializeField] private AudioClip _getGold;
    [SerializeField] private AudioClip _deliveFood;
    [SerializeField] private AudioClip _levelComplete;

    public void PlayGetFood()
    {
        _sfxSource.PlayOneShot(_getFood);
    }

    public void PlayGetGold()
    {
        _sfxSource.PlayOneShot(_getGold);
    }

    public void PlayDeliveFood()
    {
        _sfxSource.PlayOneShot(_deliveFood);
    }

    public void PlayLevelComplete()
    {
        _sfxSource.PlayOneShot(_levelComplete);
    }
}
