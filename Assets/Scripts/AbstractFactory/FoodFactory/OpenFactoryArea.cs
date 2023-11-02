using UnityEngine;

public class OpenFactoryArea : GoldDeliveryArea
{
    [SerializeField] ProductFactory _productFactory;
    [SerializeField] Transform _factoryPreparation;

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
        _factoryPreparation.gameObject.SetActive(false);
    }
}
