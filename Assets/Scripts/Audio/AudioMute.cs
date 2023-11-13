using UnityEngine;

public class AudioMute : MonoBehaviour
{
    public void MuteToggle(bool isMute)
    {
        if (isMute)
        {
            AudioListener.volume = 0;

            PlayerPrefs.SetInt(PlayerKeys.IsAudioToggleOn.ToString(), 1);
        }
        else
        {
            AudioListener.volume = PlayerPrefs.GetFloat(PlayerKeys.MusicVolume.ToString(), 0.5f);

            PlayerPrefs.SetInt(PlayerKeys.IsAudioToggleOn.ToString(), 0);
        }
    }
}
