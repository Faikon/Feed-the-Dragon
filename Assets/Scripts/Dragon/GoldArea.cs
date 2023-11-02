using System;
using TMPro;
using UnityEngine;

public class GoldArea : ProductFactory
{
    public event Action GoldTransfered;

    [SerializeField] private TMP_Text _goldText;

    private int _goldViewPerGold = 5;

    public int Gold { get; private set; }

    private void OnEnable()
    {
        GoldTransfered += TransferGold;
    }

    private void OnDisable()
    {
        GoldTransfered -= TransferGold;
    }

    private void Start()
    {
        _maxProduct = 0;
        _goldText.text = Gold.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            if (Gold > 0)
            {
                player.AddGold(Gold);
                GoldTransfered?.Invoke();
            }
        }
    }

    public void AddGold(int gold)
    {
        if (gold > 0)
            Gold += gold;

        _goldText.text = Gold.ToString();
        _maxProduct = Gold / _goldViewPerGold;
    }

    private void TransferGold()
    {
        Gold = 0;
        _maxProduct = 0;
        _goldText.text = Gold.ToString();
    }
}
