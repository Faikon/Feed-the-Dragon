using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFactoryArea : GoldSpendArea
{
    [SerializeField] ProductFactory _productFactory;

    private void OnEnable()
    {
        GoldSpent += OpenFactory;
    }

    private void OnDisable()
    {
        GoldSpent -= OpenFactory;
    }

    private void OpenFactory()
    {
        _productFactory.gameObject.SetActive(true);
    }
}
