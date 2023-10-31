using TMPro;
using UnityEngine;

public class PlayerGold : MonoBehaviour
{
    [SerializeField] private TMP_Text _gold;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _gold.text = _player.Gold.ToString();
        _player.GoldChanged += OnGoldChanged;
    }

    private void OnDisable()
    {
        _player.GoldChanged -= OnGoldChanged;
    }

    private void OnGoldChanged(int gold)
    {
        _gold.text = gold.ToString();
    }
}
