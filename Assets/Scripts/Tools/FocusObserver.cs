using Agava.WebUtility;
using UnityEngine;

public class FocusObserver : MonoBehaviour
{
    private void OnEnable()
    {
        Application.focusChanged += OnInBackgroundChange;
        WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
    }

    private void OnDisable()
    {
        Application.focusChanged -= OnInBackgroundChange;
        WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;
    }

    private void OnInBackgroundChange(bool isBackground)
    {
        MuteAudio(isBackground);
        PauseGame(isBackground);
    }

    private void MuteAudio(bool value)
    {
        AudioListener.pause = value;
        AudioListener.volume = value ? 0f : PlayerPrefs.GetFloat(PlayerKeys.MusicVolume.ToString(), 0.5f);
    }

    private void PauseGame(bool value)
    {
        Time.timeScale = value ? 0 : 1;
    }
}
