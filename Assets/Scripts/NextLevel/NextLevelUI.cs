using UnityEngine;
using UnityEngine.UI;

public class NextLevelUI : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private SfxClips _sfxClips;
    [SerializeField] private FocusObserver _focusObserver;

    private void OnTriggerEnter(Collider other)
    {
        _sfxClips.PlayLevelComplete();
        _canvas.gameObject.SetActive(true);
        _pauseButton.gameObject.SetActive(false);
        Time.timeScale = 0;

        _focusObserver.SetCurrentTimeScale(0f);
        //_focusObserver.gameObject.SetActive(false);
    }
}
