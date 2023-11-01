using UnityEngine;

public class OpenFactoryArea : GoldDeliveryArea
{
    [SerializeField] ProductFactory _productFactory;

    private void OnEnable()
    {
        GoldDelivered += OpenFactory;
    }

    private void OnDisable()
    {
        GoldDelivered -= OpenFactory;
    }

    private void OpenFactory()
    {
        _productFactory.gameObject.SetActive(true);
    }
}
