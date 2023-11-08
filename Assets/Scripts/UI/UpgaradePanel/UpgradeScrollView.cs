using UnityEngine;

public class UpgradeScrollView : DynamicScrollView
{
    [SerializeField] private PlayerKeys _upgradeKey;

    private void OnEnable()
    {
        FillUpgradeView();
    }

    public void FillUpgradeView()
    {
        FillView(PlayerPrefs.GetInt(_upgradeKey.ToString()));
    }
}
