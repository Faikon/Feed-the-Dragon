using UnityEngine;

public static class TimeFormat
{
    public static string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time - minutes * 60);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
