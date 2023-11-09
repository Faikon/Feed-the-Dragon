using UnityEngine;

[RequireComponent (typeof(LevelRewards))]
[RequireComponent (typeof(PlayerMoney))]
public class RewardPlayer : MonoBehaviour
{
    [SerializeField] private ScenesNames _sceneName;
    [SerializeField] private StarsRequirements _starsRequirements;
    [SerializeField] private LevelTimer _levelTimer;
    [SerializeField] private PlayerKeys _levelStarsKey;

    private LevelRewards _levelRewards;
    private PlayerMoney _playerMoney;
    private int sceneNameOffset = 2;
    private int _currentStars;

    private void Awake()
    {
        _levelRewards = GetComponent<LevelRewards>();
        _playerMoney = GetComponent<PlayerMoney>();
        _currentStars = PlayerPrefs.GetInt(_levelStarsKey.ToString());
    }

    private void OnEnable()
    {
        AddMoney();
        SetStars();

        PlayerPrefs.Save();
    }

    public void AddMoney()
    {
        int money = _levelRewards.GetRewardByIndex((int)_sceneName - sceneNameOffset);
        _playerMoney.AddMoney(money);
    }

    private void SetStars()
    {
        int starsCount = 0;

        for (int i = 0; i < _starsRequirements.GetStarsCount(); i++)
        {
            if (_levelTimer.Timer < _starsRequirements.GetStarRequirementByIndex(i))
            {
                starsCount++;
            }
        }

        if (starsCount > _currentStars)
        {
            PlayerPrefs.SetInt(_levelStarsKey.ToString(), starsCount);
        }
    }
}
