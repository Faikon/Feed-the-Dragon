using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodReciever : MonoBehaviour
{
    [SerializeField] private GoldArea _goldArea;
    [SerializeField] private List<ProductsPool> _foodPools;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Food>(out Food food))
        {
            if (food != null)
            {
                foreach (var pool in _foodPools)
                {
                    if (food.Type == pool.GetProductType())
                    {
                        _goldArea.AddGold(food.Reward);
                        pool.Return(food.gameObject);
                    }
                }
            }
        }
    }
}
