using UnityEngine;
using UnityEngine.UI;

public class NextLevelUI : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private SfxClips _sfxClips;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _sfxClips.PlayLevelComplete();
            _canvas.gameObject.SetActive(true);
            _pauseButton.gameObject.SetActive(false);
            Time.timeScale = 0;
        }
    }
}
