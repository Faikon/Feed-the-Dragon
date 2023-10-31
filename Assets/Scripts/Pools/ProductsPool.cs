public class ProductsPool : ObjectsPool
{
    public ProductType GetProductType()
    {
        _prefab.TryGetComponent<Product>(out Product product);

        return product.Type;
    }
}
