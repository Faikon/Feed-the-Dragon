using UnityEngine;
using UnityEngine.UI;

public class VolumeChanger : MonoBehaviour
{
    [SerializeField] private Toggle _audioToggle;

    public void ChangeVolume(float value)
    {
        _audioToggle.isOn = false;

        AudioListener.volume = value;
    }
}
