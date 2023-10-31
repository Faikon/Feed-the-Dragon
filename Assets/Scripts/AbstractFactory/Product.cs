using UnityEngine;

public abstract class Product : MonoBehaviour
{
    [SerializeField] private ProductType _type;

    public ProductType Type => _type;
}

public enum ProductType
{
    Food1,
    Food2,
    Food3,
    Food4,
    Gold
}
