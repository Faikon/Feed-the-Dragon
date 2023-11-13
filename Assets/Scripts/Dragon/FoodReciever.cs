using System;
using System.Collections.Generic;
using UnityEngine;

public class FoodReciever : MonoBehaviour
{
    public event Action IsRecieved;

    [SerializeField] private GoldArea _goldArea;
    [SerializeField] private List<ProductsPool> _foodPools;
    [SerializeField] private SfxClips _sfxClips;

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
                        _sfxClips.PlayDeliveFood();

                        _goldArea.AddGold(food.Reward);
                        pool.Return(food.gameObject);
                        IsRecieved?.Invoke();
                    }
                }
            }
        }
    }
}
