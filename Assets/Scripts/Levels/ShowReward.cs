using TMPro;
using UnityEngine;

[RequireComponent(typeof(LevelRewards))]
public class ShowReward : MonoBehaviour
{
    [SerializeField] private TMP_Text _rewardText;
    [SerializeField] private ScenesNames _sceneName;

    private LevelRewards _levelRewards;
    private int sceneNameOffset = 2;

    private void Awake()
    {
        _levelRewards = GetComponent<LevelRewards>();
    }

    private void OnEnable()
    {
        ChangeText();
    }

    private void ChangeText()
    {
        _rewardText.text = _levelRewards.GetRewardByIndex((int)_sceneName - sceneNameOffset).ToString();
    }
}
