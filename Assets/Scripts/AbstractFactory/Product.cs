using UnityEngine;

public abstract class Product : MonoBehaviour
{
    [SerializeField] private ProductType _type;

    public ProductType Type => _type;
}

public enum ProductType
{
    Avocado,
    Banana,
    Cheese,
    Chicken,
    Gold
}
