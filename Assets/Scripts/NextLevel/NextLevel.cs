using TMPro;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private GoldSpendArea _goldSpendArea;
    [SerializeField] private TMP_Text _message;

    private void OnEnable()
    {
        _goldSpendArea.GoldSpent += OnGoldSpent;
    }

    private void OnDisable()
    {
        _goldSpendArea.GoldSpent -= OnGoldSpent;
    }

    private void OnGoldSpent()
    {
        _message.gameObject.SetActive(true);
    }
}
