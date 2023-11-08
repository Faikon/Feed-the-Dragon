using UnityEngine;
using UnityEngine.UI;

public class NextLevelAreaView : GoldDeliveryAreaView
{
    [SerializeField] private Collider _nextLevelCollider;
    [SerializeField] private Image _lockImage;

    protected override void OnGoldDelivered()
    {
        base.OnGoldDelivered();

        _nextLevelCollider.enabled = false;
        _lockImage.enabled = false;
    }
}
