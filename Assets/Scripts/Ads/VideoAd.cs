using System;
using UnityEngine;
using UnityEngine.UI;

public class VideoAd : MonoBehaviour
{
    public event Action VideoAdRewarded;

    [SerializeField] private Toggle _audioToggle;
    [SerializeField] private RewardPlayer _reward;
    [SerializeField] private FocusObserver _focusObserver;

    public void Show()
    {
        Agava.YandexGames.VideoAd.Show(OnOpenCallback, OnRewardCallback, OnCloseCallback);
    }

    private void OnOpenCallback()
    {
        Time.timeScale = 0;
        AudioListener.volume = 0f;

        _focusObserver.gameObject.SetActive(false);
    }

    private void OnRewardCallback()
    {
        _reward.AddMoney();

        VideoAdRewarded?.Invoke();
    }

    private void OnCloseCallback()
    {
        Time.timeScale = 0;

        if (_audioToggle.isOn == false)
        {
            AudioListener.volume = PlayerPrefs.GetFloat(PlayerKeys.MusicVolume.ToString(), 0.5f);
        }
    }
}
