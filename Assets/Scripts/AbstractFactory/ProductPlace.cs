using System.Linq;
using UnityEngine;

public abstract class ProductPlace: MonoBehaviour
{
    public virtual float GetCurrentOffsetY(Product product)
    {
        return product.transform.localScale.y * transform.childCount;
    }

    public virtual Product GetTopProduct()
    {
        Product[] allProducts = GetComponentsInChildren<Product>();

        if (allProducts != null)
            return allProducts.Last();

        return null;
    }
}
