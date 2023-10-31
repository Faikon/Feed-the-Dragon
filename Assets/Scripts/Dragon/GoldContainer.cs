using UnityEngine;

public class GoldContainer : ProductContainer
{
    [SerializeField] private ProductsPool _goldPool;

    private GoldArea _goldArea;

    protected override void Awake()
    {
        base.Awake();

        _goldArea = GetComponentInParent<GoldArea>();
    }

    private void OnEnable()
    {
        _goldArea.GoldTransfered += RemoveGold;
    }

    private void OnDisable()
    {
        _goldArea.GoldTransfered -= RemoveGold;
    }

    private void RemoveGold()
    {
        Gold[] allGold = GetComponentsInChildren<Gold>();

        foreach (Gold gold in allGold)
            _goldPool.Return(gold.gameObject);
    }
}
