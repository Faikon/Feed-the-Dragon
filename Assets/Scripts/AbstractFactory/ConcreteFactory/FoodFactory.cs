using System.Collections.Generic;
using UnityEngine;

public class FoodFactory : ProductFactory
{
    [SerializeField] private List<GoldSpendArea> _speedUpgradeAreas;
    [SerializeField] private List<GoldSpendArea> _capacityUpgradeAreas;
    [SerializeField] private float _speedUpgradeMultiplier;
    [SerializeField] private int _capacityUpgradeAddition;

    private int _currentSpeedUpgradeAreaIndex = 0;
    private int _currentCapacityUpgradeAreaIndex = 0;

    private void OnEnable()
    {
        foreach (var area in _speedUpgradeAreas)
        {
            area.GoldSpent += SpeedUpgrade;
        }

        foreach (var area in _capacityUpgradeAreas)
        {
            area.GoldSpent += CapacityUpgrade;
        }
    }

    private void OnDisable()
    {
        foreach (var area in _speedUpgradeAreas)
        {
            area.GoldSpent -= SpeedUpgrade;
        }

        foreach (var area in _capacityUpgradeAreas)
        {
            area.GoldSpent -= CapacityUpgrade;
        }
    }

    public void SpeedUpgrade()
    {
        _timeToCreate /= _speedUpgradeMultiplier;

        _currentSpeedUpgradeAreaIndex = ActivateNextUpgradeArea(_speedUpgradeAreas, _currentSpeedUpgradeAreaIndex);
    }

    public void CapacityUpgrade()
    {
        _maxProduct += _capacityUpgradeAddition;

        _currentCapacityUpgradeAreaIndex = ActivateNextUpgradeArea(_capacityUpgradeAreas, _currentCapacityUpgradeAreaIndex);
    }

    private int ActivateNextUpgradeArea(List<GoldSpendArea> upgradeAreas,int currentUpgradeAreaIndex)
    {
        if (upgradeAreas.Count > currentUpgradeAreaIndex + 1)
        {
            upgradeAreas[currentUpgradeAreaIndex + 1].gameObject.SetActive(true);
            currentUpgradeAreaIndex++;
        }

        return currentUpgradeAreaIndex;
    }
}
