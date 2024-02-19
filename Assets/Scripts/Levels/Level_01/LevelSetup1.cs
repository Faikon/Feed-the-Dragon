using UnityEngine;

public class LevelSetup1 : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private int _startGold = 200;

    private void Start()
    {
        _player.AddGold(_startGold);
    }
}
