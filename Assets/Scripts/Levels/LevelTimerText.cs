using TMPro;
using UnityEngine;

public class LevelTimerText : MonoBehaviour
{
    [SerializeField] private LevelTimer _levelTimer;
    [SerializeField] private TMP_Text _timerText;

    private void Update()
    {
        _timerText.text = TimeFormat.FormatTime(_levelTimer.Timer);
    }
}
