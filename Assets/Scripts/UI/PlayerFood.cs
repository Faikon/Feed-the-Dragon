using TMPro;
using UnityEngine;

public class PlayerFood : MonoBehaviour
{
    [SerializeField] private TMP_Text _food;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _food.text = "0 / " + _player.MaxFood.ToString();

        _player.FoodCountChanged += OnFoodCountChanged;
    }

    private void OnDisable()
    {
        _player.FoodCountChanged -= OnFoodCountChanged;
    }

    private void OnFoodCountChanged(int currentFood, int maxFood)
    {
        _food.text = currentFood + " / " + maxFood;
    }
}
