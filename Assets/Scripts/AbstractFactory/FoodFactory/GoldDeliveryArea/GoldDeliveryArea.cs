using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class GoldDeliveryArea : DeliveryArea
{
    public event Action GoldDelivered;
    public event Action<int, int> GoldDelivering;

    [SerializeField] private int _goldToDelive;
    [SerializeField] private int _minimumGoldToDelive;
    [SerializeField] private TMP_Text _goldText;

    private int _currentGoldToDelive;

    private void Start()
    {
        _currentGoldToDelive = _goldToDelive;
        _goldText.text = _currentGoldToDelive.ToString();
    }

    protected override IEnumerator Delive(Player player)
    {
        var deliveringDelay = new WaitForSeconds(1f);

        yield return deliveringDelay;

        var timeToDelive = new WaitForSecondsRealtime(0.1f);

        while (_isDelivering)
        {
            if (_currentGoldToDelive - _minimumGoldToDelive >= 0 && player.TrySpendGold(_minimumGoldToDelive))
            {
                _currentGoldToDelive -= _minimumGoldToDelive;
                _goldText.text = _currentGoldToDelive.ToString();

                GoldDelivering?.Invoke(_currentGoldToDelive, _goldToDelive);
            }

            if (_currentGoldToDelive <= 0)
            {
                GoldDelivered?.Invoke();

                gameObject.SetActive(false);
            }

            yield return timeToDelive;
        }
    }
}
