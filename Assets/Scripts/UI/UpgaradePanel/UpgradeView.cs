using TMPro;
using UnityEngine;

public class UpgradeView : MonoBehaviour
{
    [SerializeField] private UpgradeButton _upgradeButton;
    [SerializeField] private PlayerUpgrade _playerUpgrades;
    [SerializeField] private UpgradeScrollView _upgradeScrollView;
    [SerializeField] private PlayerMoneyText _playerMoneyText;
    [SerializeField] private TMP_Text _crystalsText;

    public void Upgrade()
    {
        if (_playerUpgrades.TryUpgrade())
        {
            _upgradeButton.SetText();
            _playerMoneyText.SetText();
            _upgradeScrollView.FillUpgradeView();
        }
        else
        {
            _crystalsText.GetComponent<Animator>().Play("CrystalsAnimation");
        }
    }
}
