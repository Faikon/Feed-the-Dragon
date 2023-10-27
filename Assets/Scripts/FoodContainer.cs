using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class FoodContainer : MonoBehaviour
{
    private FoodPlace[] _foodPlaces;
    private int _foodPlaceCount;

    public int FoodPlaceCount => _foodPlaceCount;

    private void Awake()
    {
        _foodPlaces = GetComponentsInChildren<FoodPlace>();
        _foodPlaceCount = _foodPlaces.Length;
    }

    public int CountFood()
    {
        return GetComponentsInChildren<Food>().Length;
    }

    public FoodPlace GetFoodPlaceByIndex(int index)
    {
        return _foodPlaces[index];
    }

    private FoodPlace FindMaxStack()
    {
        int maxFoodCount = 0;
        FoodPlace maxFoodPlace = null;

        foreach (var foodPlace in _foodPlaces)
        {
            if (foodPlace.transform.childCount > maxFoodCount)
            {
                maxFoodCount = foodPlace.transform.childCount;
                maxFoodPlace = foodPlace;
            }
        }

        return maxFoodPlace;
    }

    private Food FindTopFoodInMaxStack()
    {
        FoodPlace maxFoodPlace = FindMaxStack();

        Food food = null;

        if (maxFoodPlace != null)
        {
            Food[] allFood = maxFoodPlace.transform.GetComponentsInChildren<Food>();
            food = allFood.Last();
        }

        return food;
    }

    public Food TakeFood()
    {
        return FindTopFoodInMaxStack();
    }
}
