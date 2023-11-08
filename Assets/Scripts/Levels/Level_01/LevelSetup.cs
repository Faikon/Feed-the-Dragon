using UnityEngine;

public class LevelSetup : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private int _startGold = 20;

    private void Start()
    {
        _player.AddGold(_startGold);
    }
}
