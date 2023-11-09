using Agava.WebUtility;
using UnityEngine;

public class FocusObserver : MonoBehaviour
{
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

    private void OnInBackgroundChangeApp(bool isBackground)
    {
        Debug.Log("isBackApp: " + isBackground);

        MuteAudio(!isBackground);
        PauseGame(!isBackground);

        Debug.Log("timeScale from App: " + Time.timeScale);
        Debug.Log("audio.pause from App: " + AudioListener.pause);
        Debug.Log("audio.volume from App: " + AudioListener.volume);
    }
    
    private void OnInBackgroundChangeWeb(bool isBackground)
    {
        Debug.Log("isBackWeb: " + isBackground);

        MuteAudio(isBackground);
        PauseGame(isBackground);

        Debug.Log("timeScale from Web: " + Time.timeScale);
        Debug.Log("audio.pause from Web: " + AudioListener.pause);
        Debug.Log("audio.volume from Web: " + AudioListener.volume);
    }

    private void MuteAudio(bool value)
    {
        //AudioListener.pause = !value;
        //AudioListener.volume = value ? PlayerPrefs.GetFloat(PlayerKeys.MusicVolume.ToString(), 0.5f) : 0f;

        AudioListener.pause = value;
        AudioListener.volume = value ? 0f : PlayerPrefs.GetFloat(PlayerKeys.MusicVolume.ToString(), 0.5f);
    }

    private void PauseGame(bool value)
    {
        //Time.timeScale = value ? 1 : 0;

        Time.timeScale = value ? 0 : 1;
    }
}
