using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(LevelRewards))]
[RequireComponent (typeof(PlayerMoney))]
public class RewardPlayer : MonoBehaviour
{
    private const string LeaderboardName = "Leaderboard";

    [SerializeField] private ScenesNames _sceneName;
    [SerializeField] private StarsRequirements _starsRequirements;
    [SerializeField] private LevelTimer _levelTimer;
    [SerializeField] private List<PlayerKeys> _levelStarsKeys;
    [SerializeField] private PlayerKeys _levelStarsKey;

    private LevelRewards _levelRewards;
    private PlayerMoney _playerMoney;
    private int sceneNameOffset = 2;
    private int _currentStars;
    private int _score;

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
        SetScore();
        SetPlayerToLeaderboard();

        PlayerPrefs.Save();
    }

    public void AddMoney()
    {
        int money = _levelRewards.GetRewardByIndex((int)_sceneName - sceneNameOffset);
        _playerMoney.AddMoney(money);
    }

    public int GetStars()
    {
        int starsCount = 0;

        for (int i = 0; i < _starsRequirements.GetStarsCount(); i++)
        {
            if (_levelTimer.Timer < _starsRequirements.GetStarRequirementByIndex(i))
            {
                starsCount++;
            }
        }

        return starsCount;
    }

    private void SetStars()
    {
        int starsCount = GetStars();

        if (starsCount > _currentStars)
        {
            PlayerPrefs.SetInt(_levelStarsKey.ToString(), starsCount);
        }
    }

    private void SetScore()
    {
        _score = 0;

        foreach (var key in _levelStarsKeys)
        {
            _score += PlayerPrefs.GetInt(key.ToString());
        }

        PlayerPrefs.SetInt(PlayerKeys.Score.ToString(), _score);
    }

    private void SetPlayerToLeaderboard()
    {
        if (Agava.YandexGames.PlayerAccount.IsAuthorized == false)
            return;

        Agava.YandexGames.Leaderboard.GetPlayerEntry(LeaderboardName, onSuccessCallback =>
        {
            Agava.YandexGames.Leaderboard.SetScore(LeaderboardName, _score);
        });
    }
}
