using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _foodPlace;
    [SerializeField] private int _maxFood;

    public event UnityAction<int> GoldChanged;
    public int Gold { get; private set; }

    private Transform _transform;
    private List<Food> _food = new List<Food>();   
    private Coroutine _collectFood;
    private bool _isCollectingFood;

    private void Awake()
    {
        _transform = transform;
        _isCollectingFood = false;
    }

    private void Update()
    {
        StackFood();
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
            _isCollectingFood = false;
    }

    public void AddGold(int gold)
    {
        Gold += gold;
        GoldChanged?.Invoke(gold);
    }

    public Food GiveFood()
    {
        Food food = null;

        if (_food.Count > 0)
        {
            food = _food.Last();
            _food.RemoveAt(_food.Count - 1);
        }

        return food;
    }

    private float CalculateItemOffsetY(Transform item)
    {
        return item.localScale.y;
    }

    private void StackItems(Transform firstItem, Transform secondItem)
    {
        float followSpeed = 35f;

        secondItem.position = new Vector3(Mathf.Lerp(secondItem.position.x, firstItem.position.x, Time.deltaTime * followSpeed),
                    Mathf.Lerp(secondItem.position.y, firstItem.position.y + CalculateItemOffsetY(firstItem), Time.deltaTime * followSpeed), firstItem.position.z);
    }

    private void StackFood()
    {
        for (int i = 0; i < _food.Count; i++)
        {
            if (i == 0)
                StackItems(_foodPlace, _food[i].transform);
            else
                StackItems(_food.ElementAt(i - 1).transform, _food.ElementAt(i).transform);
        }
    }

    private void DeliveFood(Collider collider)
    {
        if (collider.TryGetComponent<DeliveryArea>(out DeliveryArea deliveryArea))
        {

        }
    }

    private IEnumerator CollectFood(FoodContainer foodContainer)
    {
        var timeToCollect = new WaitForSecondsRealtime(0.15f);

        while (_isCollectingFood)
        {
            if (_food.Count < _maxFood)
            {
                Food food = foodContainer.TakeFood();

                if (food != null)
                {
                    _food.Add(food);
                    food.transform.SetParent(null);
                }
            }

            yield return timeToCollect;
        }
    }
}
