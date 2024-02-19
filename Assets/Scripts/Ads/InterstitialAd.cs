using UnityEngine;
using UnityEngine.UI;

public class InterstitialAd : MonoBehaviour
{
    [SerializeField] private Toggle _audioToggle;
    [SerializeField] private FocusObserver _focusObserver;

    private void Start()
    {
        Show();
    }

    private void Show()
    {
        Agava.YandexGames.InterstitialAd.Show(OnOpenCallback, OnCloseCallback);
    }

    private void OnOpenCallback()
    {
        //_focusObserver.SetCurrentTimeScale(0f);

        Time.timeScale = 0;
        AudioListener.volume = 0f;

        _focusObserver.gameObject.SetActive(false);
    }

    private void OnCloseCallback(bool state)
    {
        SetTimeScale();
        SetAudioVolume();

        _focusObserver.gameObject.SetActive(true);
    }

    private void SetTimeScale()
    {
        Time.timeScale = 1.0f;
    }

    private void SetAudioVolume()
    {
        if (_audioToggle.isOn == false)
        {
            AudioListener.volume = PlayerPrefs.GetFloat(PlayerKeys.MusicVolume.ToString(), 0.5f);
        }
    }
}
