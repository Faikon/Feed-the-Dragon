using UnityEngine;

public class PausePanel : MonoBehaviour
{
    [SerializeField] FocusObserver _focusObserver;

    public void Pause()
    {
        Time.timeScale = 0f;
        _focusObserver.gameObject.SetActive(false);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        _focusObserver.gameObject.SetActive(true);
    }
}
