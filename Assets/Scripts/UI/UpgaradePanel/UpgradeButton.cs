using TMPro;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] TMP_Text _upgradeCostText;
    [SerializeField] private PlayerUpgrade _playerUpgrades;
    [SerializeField] private PlayerKeys _upgradeKey;

    private string _maxText = "MAX";

    private void OnEnable()
    {
        SetText();
    }

    public void SetText()
    {
        if (_playerUpgrades.TryGetCurrentUpgradeCost(out int upgradeCost))
        {
            _upgradeCostText.text = upgradeCost.ToString();
        }
        else
        {
            _upgradeCostText.text = _maxText;
        }
    }
}
