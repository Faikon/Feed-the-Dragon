using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Transform _foodPlace;
    [SerializeField] private int _maxFood;

    private Transform _transform;
    private List<Food> _food = new List<Food>();
    private CharacterController _characterController;
    private Coroutine _collectFoodCoroutin;

    private void Awake()
    {
        _transform = transform;
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Movement();
        StackFood();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<FoodContainer>(out FoodContainer foodContainer))
        {
            _collectFoodCoroutin = StartCoroutine(CollectFood(foodContainer));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<FoodContainer>(out FoodContainer foodContainer))
        {
            /*if (_collectFoodCoroutin != null)
            {
                StopCoroutine(_collectFoodCoroutin);
                _collectFoodCoroutin = null;
            }*/
            
            StopAllCoroutines();
        }
    }

    private void Movement()
    {
        Vector2 inputVector = _playerInput.GetInputVectorNormalized();

        Vector3 moveDirection = new Vector3(inputVector.x, 0, inputVector.y);

        if (_characterController.isGrounded)
        {
            _characterController.Move(moveDirection * _moveSpeed * Time.deltaTime + Vector3.down);
            _transform.forward = Vector3.Slerp(_transform.forward, moveDirection, Time.deltaTime * _rotateSpeed);
        }
        else
        {
            _characterController.Move(_characterController.velocity + Physics.gravity * Time.deltaTime);
        }
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
        for (int i = 1; i < _food.Count; i++)
        {
            Food previousFood = _food.ElementAt(i - 1);
            Food nextFood = _food.ElementAt(i);

            if (i == 1)
                StackItems(_foodPlace, _food[i].transform);
            else
                StackItems(previousFood.transform, nextFood.transform);
        }
    }

    private FoodPlace FindMaxStack(FoodPlace[] foodPlaces)
    {
        int maxFoodCount = 0;
        FoodPlace maxFoodPlace = null;

        foreach (var foodPlace in foodPlaces)
        {
            if (foodPlace.transform.childCount > maxFoodCount)
            {
                maxFoodCount = foodPlace.transform.childCount;
                maxFoodPlace = foodPlace;
            }
        }

        return maxFoodPlace;
    }

    private Food FindTopFoodInMaxStack(FoodContainer foodContainer)
    {
        FoodPlace[] foodPlaces = foodContainer.transform.GetComponentsInChildren<FoodPlace>();

        FoodPlace maxFoodPlace = FindMaxStack(foodPlaces);

        Food food = null;

        if (maxFoodPlace != null)
        {
            Food[] allFood = maxFoodPlace.transform.GetComponentsInChildren<Food>();
            food = allFood.Last();
        }

        return food;
    }

    private IEnumerator CollectFood(FoodContainer foodContainer)
    {
        var timeToCollect = new WaitForSecondsRealtime(0.5f);

        while (Time.timeScale != 0)
        {
            if (_food.Count < _maxFood)
            {
                Food food = FindTopFoodInMaxStack(foodContainer);

                if (food != null)
                {
                    _food.Add(food);
                    food.transform.SetParent(null);
                    //food.transform.SetParent(_foodPlace.transform);
                }
            }

            yield return timeToCollect;
        }
    }

    /*private void OnTriggerStay(Collider other)
{
    if (other.TryGetComponent<FoodContainer>(out FoodContainer foodContainer))
    {
        if (_food.Count < _maxFood)
        {
            Food food = foodContainer.transform.GetComponentInChildren<Food>();

            if (food != null)
            {
                _food.Add(food);
                food.transform.SetParent(_foodPlace.transform);
            }
        }
    }
}*/
}
