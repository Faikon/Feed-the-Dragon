using System.Linq;
using UnityEngine;

public abstract class ProductPlace: MonoBehaviour
{
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    public virtual float GetCurrentOffsetY(Product product)
    {
        return product.transform.localScale.y * _transform.childCount;
    }

    public virtual Product GetTopProduct()
    {
        int childCount = _transform.childCount;

        if (childCount > 0)
        {
            Transform lastChild = _transform.GetChild(childCount - 1);
            return lastChild.GetComponent<Product>();
        }

        return null;
    }
}
