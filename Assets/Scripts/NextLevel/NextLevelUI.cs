using UnityEngine;

public class NextLevelUI : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
