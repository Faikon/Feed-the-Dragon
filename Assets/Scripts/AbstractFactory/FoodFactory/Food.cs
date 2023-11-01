using UnityEngine;

public class Food : Product
{
    [SerializeField] private int _reward;

    public int Reward => _reward;
}