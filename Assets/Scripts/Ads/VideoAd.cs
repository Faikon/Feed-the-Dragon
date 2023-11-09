using System;
using UnityEngine;

public class VideoAd : MonoBehaviour
{
    public event Action VideoAdRewarded;

    [SerializeField] private RewardPlayer _reward;

    public void Show()
    {
        Agava.YandexGames.VideoAd.Show(onOpenCallback, onRewardCallback, onCloseCallback);
    }

    private void onOpenCallback()
    {
        Time.timeScale = 0;
        AudioListener.volume = 0f;
    }

    private void onRewardCallback()
    {
        _reward.AddMoney();

        VideoAdRewarded?.Invoke();
    }

    private void onCloseCallback()
    {
        //Time.timeScale = 1;

        AudioListener.volume = PlayerPrefs.GetFloat(PlayerKeys.MusicVolume.ToString(), 0.5f);
    }
}
