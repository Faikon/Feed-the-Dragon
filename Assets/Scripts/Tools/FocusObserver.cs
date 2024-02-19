using Agava.WebUtility;
using UnityEngine;

public class FocusObserver : MonoBehaviour
{
    private float _currentTimeScale = 1f;

    private void OnEnable()
    {
        Application.focusChanged += OnInBackgroundChangeApp;
        WebApplication.InBackgroundChangeEvent += OnInBackgroundChangeWeb;
    }

    private void OnDisable()
    {
        Application.focusChanged -= OnInBackgroundChangeApp;
        WebApplication.InBackgroundChangeEvent -= OnInBackgroundChangeWeb;
    }

    public void SetCurrentTimeScale(float timeScale)
    {
        _currentTimeScale = timeScale;
    }

    private void OnInBackgroundChangeApp(bool inApp)
    {
        MuteAudio(!inApp);
        PauseGame(!inApp);
    }
    
    private void OnInBackgroundChangeWeb(bool isBackground)
    {
        MuteAudio(isBackground);
        PauseGame(isBackground);
    }

    private void MuteAudio(bool value)
    {
        AudioListener.pause = value;

        int isToggleOn = PlayerPrefs.GetInt(PlayerKeys.IsAudioToggleOn.ToString());

        if (isToggleOn == 0)
        {
            AudioListener.volume = value ? 0f : PlayerPrefs.GetFloat(PlayerKeys.MusicVolume.ToString(), 0.5f);
        }
        else
        {
            AudioListener.volume = 0;
        }

    }

    private void PauseGame(bool value)
    {
        Time.timeScale = value ? 0 : _currentTimeScale;
    }
}
