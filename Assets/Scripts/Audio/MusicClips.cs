using UnityEngine;

public class MusicClips : MonoBehaviour
{
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioClip _musicClip;

    private void Start()
    {
        _musicSource.clip = _musicClip;
        _musicSource.Play();
    }
}
