using TMPro;
using UnityEngine;

[RequireComponent(typeof(LevelRewards))]
public class ShowReward : MonoBehaviour
{
    [SerializeField] private TMP_Text _rewardText;
    [SerializeField] private ScenesNames _sceneName;
    [SerializeField] private VideoAd _videoAd;

    private LevelRewards _levelRewards;
    private int sceneNameOffset = 2;

    private void Awake()
    {
        _levelRewards = GetComponent<LevelRewards>();
    }

    private void OnEnable()
    {
        _videoAd.VideoAdRewarded += OnVideoAdRewarded;

        ChangeText();
    }

    private void OnDisable()
    {
        _videoAd.VideoAdRewarded -= OnVideoAdRewarded;
    }

    private void ChangeText()
    {
        _rewardText.text = _levelRewards.GetRewardByIndex((int)_sceneName - sceneNameOffset).ToString();
    }

    private void OnVideoAdRewarded()
    {
        string currentText = _rewardText.text;

        _rewardText.text = currentText + " + " + _rewardText.text;
    }
}
