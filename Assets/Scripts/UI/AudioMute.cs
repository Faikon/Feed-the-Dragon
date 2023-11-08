using UnityEngine;

public class AudioMute : MonoBehaviour
{
    private PlayerKeys _playerKeys;

    public void MuteToggle(bool isMute)
    {
        if (isMute)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = PlayerPrefs.GetFloat(PlayerKeys.MusicVolume.ToString(), 0.5f); ;
        }
    }
}
