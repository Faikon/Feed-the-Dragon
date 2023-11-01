using DG.Tweening;
using System.Collections;
using UnityEngine;

public class FoodDeliveryArea : DeliveryArea
{
    [SerializeField] private FoodReciever _foodReciever;
    [SerializeField] private float _timeToCollect = 0.1f;

    protected override IEnumerator Delive(Player player)
    {
        var timeToCollect = new WaitForSecondsRealtime(_timeToCollect);

        float jumpPower = 2f;
        int numJumps = 1;
        float jumpDuration = 0.5f;

        while (_isDelivering)
        {
            Food food = player.GiveFood();

            if (food != null)
                food.transform.DOJump(new Vector3(_foodReciever.transform.position.x, _foodReciever.transform.position.y, _foodReciever.transform.position.z), jumpPower, numJumps, jumpDuration).SetEase(Ease.OutQuad);

            yield return timeToCollect;
        }
    }
}
