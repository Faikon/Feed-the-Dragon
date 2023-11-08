using UnityEngine;

public class VolumeChanger : MonoBehaviour
{
    public void ChangeVolume(float value)
    {
        AudioListener.volume = value;
    }    
}
