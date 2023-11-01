using System;
using System.Collections;
using UnityEngine;

public abstract class DeliveryArea : MonoBehaviour
{
    public event Action<bool> IsDelivering;

    protected bool _isDelivering;

    private Coroutine _delive;

    private void Awake()
    {
        _isDelivering = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _isDelivering = true;
            IsDelivering?.Invoke(_isDelivering);
            _delive = StartCoroutine(Delive(player));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _isDelivering = false;
            IsDelivering?.Invoke(_isDelivering);
        }
    }

    protected abstract IEnumerator Delive(Player player);
}