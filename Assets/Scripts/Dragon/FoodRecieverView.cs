using UnityEngine;

public class FoodRecieverView : MonoBehaviour
{
    private FoodReciever _foodReciever;
    private ParticleSystem _particleSystem;

    private void Awake()
    {
        _foodReciever = GetComponentInParent<FoodReciever>();
        _particleSystem = GetComponentInChildren<ParticleSystem>();
    }

    private void OnEnable()
    {
        _foodReciever.IsRecieved += OnRecieve;
    }

    private void OnDisable()
    {
        _foodReciever.IsRecieved -= OnRecieve;
    }

    private void OnRecieve()
    {
        _particleSystem.Play();
    }
}
