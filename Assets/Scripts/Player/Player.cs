using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(FoodTransition))]
[RequireComponent(typeof(FoodStack))]
public class Player : MonoBehaviour
{
    public event Action<int> GoldChanged;
    public event Action<int, int> FoodCountChanged;

    [SerializeField] private Transform _foodPlace;
    [SerializeField] private int _maxFood;
    [SerializeField] private float _timeToCollect;

    public int Gold { get; private set; }
    public int MaxFood => _maxFood;

    private List<Food> _food = new List<Food>();  
    private List<Food> _flyingFood = new List<Food>();  
    private Coroutine _collectFood;
    private bool _isCollectingFood;
    private FoodTransition _foodTransition;
    private FoodStack _foodStack;

    private void Awake()
    {
        Gold += 2000;

        _isCollectingFood = false;

        _foodTransition = GetComponent<FoodTransition>();
        _foodStack = GetComponent<FoodStack>();
    }

    private void Update()
    {
        _foodTransition.TransitFood(_flyingFood, _food, _foodPlace.transform.position);
    }

    private void LateUpdate()
    {
        _foodStack.MoveStackFood(_food, _foodPlace);  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<FoodContainer>(out FoodContainer foodContainer))
        {
            _isCollectingFood = true;
            _collectFood = StartCoroutine(CollectFood(foodContainer));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<FoodContainer>(out FoodContainer foodContainer))
        {
            StopCoroutine(_collectFood);
            _isCollectingFood = false;
        }
    }

    public void AddGold(int gold)
    {
        if (gold > 0)
        {
            Gold += gold;
            GoldChanged?.Invoke(Gold);
        }
    }

    public bool TrySpendGold(int gold)
    {
        if (gold > 0 && Gold - gold >= 0)
        {
            Gold -= gold;
            GoldChanged?.Invoke(Gold);

            return true;
        }
        
        return false;
    }

    public Food GiveFood()
    {
        Food food = null;

        if (_food.Count > 0)
        {
            food = _food.Last();
            _food.RemoveAt(_food.Count - 1);
        }

        FoodCountChanged?.Invoke(_food.Count + _flyingFood.Count, _maxFood);

        return food;
    }

    private IEnumerator CollectFood(FoodContainer foodContainer)
    {
        var timeToCollect = new WaitForSecondsRealtime(_timeToCollect);

        while (_isCollectingFood)
        {
            if (_food.Count + _flyingFood.Count < _maxFood)
            {
                Food food = (Food)foodContainer.GetProduct();

                if (food != null)
                {
                    _flyingFood.Add(food);

                    FoodCountChanged?.Invoke(_food.Count + _flyingFood.Count, _maxFood);

                    food.transform.SetParent(null);
                }
            }

            yield return timeToCollect;
        }
    }
}
