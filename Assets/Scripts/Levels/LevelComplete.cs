using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    [SerializeField] private PlayerKeys _isLevelCompletedKey;

    private int _isLevelCompleted;

    private void Awake()
    {
        _isLevelCompleted = PlayerPrefs.GetInt(_isLevelCompletedKey.ToString());
    }

    private void OnEnable()
    {
        CompleteLevel();
    }

    private void CompleteLevel()
    {
        if (_isLevelCompleted == 0)
        {
            PlayerPrefs.SetInt(_isLevelCompletedKey.ToString(), 1);
        }
    }

    private void SetStars()
    {

    }
}
