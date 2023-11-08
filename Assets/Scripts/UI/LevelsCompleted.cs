using System.Collections.Generic;
using UnityEngine;

public class LevelsCompleted : MonoBehaviour
{
    [SerializeField] private List<PlayerKeys> _isLevelCompletedKeys;

    private void OnEnable()
    {
        int levelsCompleted = CountCompletedLevels();

        PlayerPrefs.SetInt(PlayerKeys.LevelsCompleted.ToString(), levelsCompleted);
    }

    private int CountCompletedLevels()
    {
        int levelsCompleted = 0;

        foreach (PlayerKeys key in _isLevelCompletedKeys)
        {
            int isLevelCompleted = PlayerPrefs.GetInt(key.ToString());

            if (isLevelCompleted == 1)
            {
                levelsCompleted++;
            }
        }

        return levelsCompleted;
    }
}
