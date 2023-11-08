using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

public abstract class ProductFactory : MonoBehaviour
{
    public event Action<bool> IsWorking;

    [SerializeField] protected float _timeToCreate;
    [SerializeField] protected int _maxProduct;

    [SerializeField] private ProductsPool _objectsPool;
    [SerializeField] private Transform _productCreator;

    private Coroutine _createProduct;
    private ProductContainer _productContainer;
    private int _currentProductPlaceIndex;
    private bool _isWorking;

    private void Awake()
    {
        _currentProductPlaceIndex = 0;
        _isWorking = false;
        _productContainer = GetComponentInChildren<ProductContainer>();
    }

    private void Update()
    {
        Work();
    }

    private IEnumerator CreateProduct()
    {
        var waitForGenerate = new WaitForSeconds(_timeToCreate);

        yield return new WaitForSeconds(_timeToCreate);

        while (_isWorking)
        {
            waitForGenerate = new WaitForSeconds(_timeToCreate);

            ProductPlace productPlace = _productContainer.GetProductPlaceByIndex(_currentProductPlaceIndex);
            GameObject productObject = _objectsPool.Get();
            Product product = productObject.GetComponent<Product>();

            product.transform.position = _productCreator.transform.position;

            productPlace.RecieveProduct(product, _timeToCreate);

            if (_currentProductPlaceIndex < _productContainer.ProductPlaceCount - 1)
                _currentProductPlaceIndex++;
            else
                _currentProductPlaceIndex = 0;

            yield return waitForGenerate;
        }
    }

    private void Work()
    {
        if (_productContainer.CountProducts() == _maxProduct)
        {
            _isWorking = false;
            IsWorking?.Invoke(_isWorking);

            if (_createProduct != null)
                StopCoroutine(_createProduct);
        }

        if (_productContainer.CountProducts() < _maxProduct && _isWorking == false)
        {
            _isWorking = true;
            IsWorking?.Invoke(_isWorking);
            _createProduct = StartCoroutine(CreateProduct());
        }
    }
}
