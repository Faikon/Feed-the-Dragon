using UnityEngine;
using UnityEngine.UI;

public class LevelLoad : MonoBehaviour
{
    [SerializeField] private Toggle _audioToggle;

    private void Start()
    {
        SetAudioToggle();
    }

    private void SetAudioToggle()
    {
        int currentPosition = PlayerPrefs.GetInt(PlayerKeys.IsAudioToggleOn.ToString());

        if (currentPosition == 0)
        {
            _audioToggle.isOn = false;
        }
        else
        {
            _audioToggle.isOn = true;
        }
    }
}
