using Agava.YandexGames;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    private const string AnonymousName = "Anonymous";
    private const string LeaderboardName = "Leaderboard";

    [SerializeField] private LeaderboardView _leaderboardView;
    [SerializeField] private GameObject _authorizationRequestPanel;
    [SerializeField] private GameObject _leaderboardPanel;

    private readonly List<LeaderboardPlayer> _leaderboardPlayers = new();

    public void SetPlayer(int score)
    {
        if (PlayerAccount.IsAuthorized == false)
            return;

        Agava.YandexGames.Leaderboard.GetPlayerEntry(LeaderboardName, onSuccessCallback =>
        {
            Agava.YandexGames.Leaderboard.SetScore(LeaderboardName, score);
        });
    }

    public void Fill()
    {
        _leaderboardPlayers.Clear();

        if (PlayerAccount.IsAuthorized == false)
            return;

        Agava.YandexGames.Leaderboard.GetEntries(LeaderboardName, result =>
        {
            for (int i = 0; i < result.entries.Length; i++)
            {
                var rank = result.entries[i].rank;
                var score = result.entries[i].score;
                var name = result.entries[i].player.publicName;

                if (string.IsNullOrEmpty(name))
                {
                    name = AnonymousName;
                }

                _leaderboardPlayers.Add(new LeaderboardPlayer(name, rank, score));
            }

            _leaderboardView.ConstructLeaderboard(_leaderboardPlayers);
        });
    }

    public void OpenLeaderboard()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        _authorizationRequestPanel.SetActive(true);
#else

        if (PlayerAccount.IsAuthorized)
        {
            PlayerAccount.RequestPersonalProfileDataPermission();

            _leaderboardPanel.gameObject.SetActive(true);

            SetPlayer(UnityEngine.PlayerPrefs.GetInt(PlayerKeys.Score.ToString()));

            Fill();

        }

        if (PlayerAccount.IsAuthorized == false)
        {
            _authorizationRequestPanel.SetActive(true);

            return;
        }
#endif
    }

    public void Authorize()
    {
        PlayerAccount.Authorize();
    }
}
