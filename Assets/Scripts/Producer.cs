using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Producer : MonoBehaviour
{
    [SerializeField] private Food _foodTemplate;
    [SerializeField] private float _timeToGenerate;
    [SerializeField] private int _maxFood;

    private Transform _transform;
    private float _startOffsetY;
    private float _currentOffsetY;
    private float _addOffsetY;  
    private Coroutine _produceFood;
    private FoodContainer _foodContainer;

    private void Awake()
    {
        _transform = transform;

        _foodContainer = GetComponentInChildren<FoodContainer>();

        _startOffsetY = _foodTemplate.transform.localScale.y;
        _currentOffsetY = _startOffsetY;
        _addOffsetY = _startOffsetY * 2;
    }

    private void Start()
    {
        _produceFood = StartCoroutine(ProduceFood(_timeToGenerate));
    }

    private IEnumerator ProduceFood(float timeToGenerate)
    {
        int foodIndex = 0;

        float jumpPower = 2f;
        int numJumps = 1;
        float jumpDuration = 0.5f;

        var waitForGenerate = new WaitForSecondsRealtime(timeToGenerate);

        _currentOffsetY = _startOffsetY;

        while (true)
        {
            if (_foodContainer.CountFood() < _maxFood)
            {
                FoodPlace foodPlace = _foodContainer.GetFoodPlaceByIndex(foodIndex);

                Food food = Instantiate(_foodTemplate, new Vector3(_transform.position.x, _transform.position.y, _transform.position.z), Quaternion.identity, foodPlace.transform);

                food.transform.DOJump(new Vector3(foodPlace.transform.position.x, foodPlace.transform.position.y + _currentOffsetY, foodPlace.transform.position.z), jumpPower, numJumps, jumpDuration).SetEase(Ease.OutQuad);

                if (foodIndex < _foodContainer.FoodPlaceCount - 1)
                    foodIndex++;
                else
                    foodIndex = 0;

                foodPlace = _foodContainer.GetFoodPlaceByIndex(foodIndex);
                _currentOffsetY = _startOffsetY + _addOffsetY * foodPlace.transform.childCount;
            }

           yield return waitForGenerate;
        }
    }
}
