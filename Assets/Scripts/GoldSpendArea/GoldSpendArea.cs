using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class GoldSpendArea : MonoBehaviour
{
    public event Action GoldSpent;

    [SerializeField] private int _goldToSpend;
    [SerializeField] private int _minimumGoldToSpend;
    [SerializeField] private TMP_Text _goldText;

    private Coroutine _spendGold;
    private bool _isSpending;
    private int _currentGoldToSpend;

    private void Awake()
    {
        _isSpending = false;
    }

    private void Start()
    {
        _currentGoldToSpend = _goldToSpend;
        _goldText.text = _currentGoldToSpend.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _isSpending = true;

            _spendGold = StartCoroutine(SpendGold(player));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _isSpending = false;
        }
    }

    private IEnumerator SpendGold(Player player)
    {
        var spendingDelay = new WaitForSeconds(1f);

        yield return spendingDelay;

        var timeToSpend = new WaitForSecondsRealtime(0.1f);

        while (_isSpending)
        {
            if (_currentGoldToSpend - _minimumGoldToSpend >= 0 && player.TrySpendGold(_minimumGoldToSpend))
            {
                _currentGoldToSpend -= _minimumGoldToSpend;
                _goldText.text = _currentGoldToSpend.ToString();
            }

            if (_currentGoldToSpend <= 0)
            {
                GoldSpent?.Invoke();

                gameObject.SetActive(false);
            }

            yield return timeToSpend;
        }
    }
}
