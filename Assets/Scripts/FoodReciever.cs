using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodReciever : MonoBehaviour
{
    [SerializeField] private RewardArea _rewardArea;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Food>(out Food food))
        {
            if (food != null)
            {
                _rewardArea.AddGold(food.Reward);

                Destroy(food.gameObject, 0.2f);
            }
        }
    }
}
