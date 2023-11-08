using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMoney))]
public class PlayerUpgrade : MonoBehaviour
{
    [SerializeField] private List<int> _upgradeCosts = new List<int>(10);
    [SerializeField] private PlayerKeys _upgradeKey;

    private PlayerMoney _playerMoney;

    private void Awake()
    {
        _playerMoney = GetComponent<PlayerMoney>();
    }

    public bool TryUpgrade()
    {
        int currentUpgrade = PlayerPrefs.GetInt(_upgradeKey.ToString());

        if (currentUpgrade >= _upgradeCosts.Count)
        {
            return false;
        }

        if (_playerMoney.TrySpendMoney(_upgradeCosts[currentUpgrade]))
        {
            PlayerPrefs.SetInt(_upgradeKey.ToString(), ++currentUpgrade);

            return true;
        }

        return false;
    }

    public bool TryGetCurrentUpgradeCost(out int currentUpgradeCost)
    {
        int currentUpgrade = PlayerPrefs.GetInt(_upgradeKey.ToString());

        currentUpgradeCost = 0;

        if (currentUpgrade < _upgradeCosts.Count)
        {
            currentUpgradeCost = _upgradeCosts[PlayerPrefs.GetInt(_upgradeKey.ToString())];

            return true;
        }

        return false;
    }
}
