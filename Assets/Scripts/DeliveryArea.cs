using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryArea : MonoBehaviour
{
    [SerializeField] private FoodReciever _foodReciever;

    private Coroutine _deliveFood;
    private bool _isDelivering;

    private void Awake()
    {
        _isDelivering = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _isDelivering = true;
            _deliveFood = StartCoroutine(DeliveFood(player));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
            _isDelivering = false;
    }

    private IEnumerator DeliveFood(Player player)
    {
        var timeToCollect = new WaitForSecondsRealtime(0.3f);

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
