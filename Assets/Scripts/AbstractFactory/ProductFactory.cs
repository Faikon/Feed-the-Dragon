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
        float offsetY = 0;

        float jumpPower = 4f;
        int numJumps = 1;
        float jumpDuration = 0.7f;

        var waitForGenerate = new WaitForSecondsRealtime(_timeToCreate);

        while (_isWorking)
        {
            waitForGenerate = new WaitForSecondsRealtime(_timeToCreate);

            if (jumpDuration > _timeToCreate)
                jumpDuration = _timeToCreate;

            ProductPlace productPlace = _productContainer.GetProductPlaceByIndex(_currentProductPlaceIndex);
            GameObject productObject = _objectsPool.Get();
            Product product = productObject.GetComponent<Product>();

            offsetY = productPlace.GetCurrentOffsetY(product);

            product.transform.position = _productCreator.transform.position;

            Tween productJump = product.transform.DOJump(new Vector3(productPlace.transform.position.x, productPlace.transform.position.y + offsetY, productPlace.transform.position.z), jumpPower, numJumps, jumpDuration).SetEase(Ease.OutQuad);

            yield return productJump.WaitForCompletion();

            product.transform.SetParent(productPlace.transform);

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
        }

        if (_productContainer.CountProducts() < _maxProduct && _isWorking == false)
        {
            _isWorking = true;
            IsWorking?.Invoke(_isWorking);
            _createProduct = StartCoroutine(CreateProduct());
        }
    }
}
