using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodFactory : ProductFactory
{
    [SerializeField] private GoldSpendArea _speedUpgradeArea;
    [SerializeField] private GoldSpendArea _capacityUpgradeArea;

    private void OnEnable()
    {
        _speedUpgradeArea.GoldSpent += SpeedUpgrade;
        _capacityUpgradeArea.GoldSpent += CapacityUpgrade;
    }

    private void OnDisable()
    {
        _speedUpgradeArea.GoldSpent -= SpeedUpgrade;
        _capacityUpgradeArea.GoldSpent -= CapacityUpgrade;
    }

    public void SpeedUpgrade()
    {
        _timeToCreate /= 2f;
    }

    public void CapacityUpgrade()
    {
        _maxProduct += 10;
    }
}
