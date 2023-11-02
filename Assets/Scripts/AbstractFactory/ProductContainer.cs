using UnityEngine;

public abstract class ProductContainer : MonoBehaviour
{
    [SerializeField] private ProductPlace[] _productPlaces;
    private int _productPlaceCount;

    public int ProductPlaceCount => _productPlaceCount;

    protected virtual void Awake()
    {
        //_productPlaces = GetComponentsInChildren<ProductPlace>();
        _productPlaceCount = _productPlaces.Length;
    }

    public virtual int CountProducts()
    {
        return GetComponentsInChildren<Product>().Length;
    }

    public virtual ProductPlace GetProductPlaceByIndex(int index)
    {
        return _productPlaces[index];
    }

    public virtual Product GetProduct()
    {
        return GetTopProductInMaxFoodPlace();
    }

    private ProductPlace GetMaxFoodPlace()
    {
        int maxProductCount = 0;
        ProductPlace maxProductPlace = null;

        foreach (var productPlace in _productPlaces)
        {
            if (productPlace.transform.childCount > maxProductCount)
            {
                maxProductCount = productPlace.transform.childCount;
                maxProductPlace = productPlace;
            }
        }

        return maxProductPlace;
    }

    private Product GetTopProductInMaxFoodPlace()
    {
        return GetMaxFoodPlace()?.GetTopProduct();
    }
}
