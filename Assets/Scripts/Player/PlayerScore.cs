using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private List<PlayerKeys> _levelStarsKeys;

    private int _score;

    private void OnEnable()
    {
        CountScore();
    }

    private void CountScore()
    {
        _score = 0;

        foreach (var key in _levelStarsKeys)
        {
            _score += PlayerPrefs.GetInt(key.ToString());
        }

        PlayerPrefs.SetInt(PlayerKeys.Score.ToString(), _score);
    }
}
