using TMPro;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private GoldDeliveryArea _goldDeliveryArea;
    [SerializeField] private TMP_Text _message;

    private void OnEnable()
    {
        _goldDeliveryArea.GoldDelivered += OnGoldSpent;
    }

    private void OnDisable()
    {
        _goldDeliveryArea.GoldDelivered -= OnGoldSpent;
    }

    private void OnGoldSpent()
    {
        _message.gameObject.SetActive(true);
    }
}
