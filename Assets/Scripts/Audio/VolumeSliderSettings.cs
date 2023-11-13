using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderSettings : MonoBehaviour
{
    [SerializeField] private Slider _sfxVolumeSlider;
    [SerializeField] private Slider _musicVolumeSlider;

    private float _sfxVolume;
    private float _musicVolume;

    public void LoadSettings()
    {
        _sfxVolume = PlayerPrefs.GetFloat(PlayerKeys.SfxVolume.ToString(), 0.5f);
        _musicVolume = PlayerPrefs.GetFloat(PlayerKeys.MusicVolume.ToString(), 0.5f);

        _sfxVolumeSlider.value = _sfxVolume;
        _musicVolumeSlider.value = _musicVolume;
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat(PlayerKeys.SfxVolume.ToString(), _sfxVolumeSlider.value);
        PlayerPrefs.SetFloat(PlayerKeys.MusicVolume.ToString(), _musicVolumeSlider.value);

        PlayerPrefs.Save();
    }
}
