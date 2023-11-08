using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private List<PlayerKeys> _levelStarsKeys;

    public int Score { get; private set; }

    private void OnEnable()
    {
        CountScore();
    }

    private void CountScore()
    {
        Score = 0;

        foreach (var key in _levelStarsKeys)
        {
            Score += PlayerPrefs.GetInt(key.ToString());
        }
    }
}
