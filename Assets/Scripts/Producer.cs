using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Producer : MonoBehaviour
{
    [SerializeField] private Food _foodTemplate;
    [SerializeField] private float _timeToGenerate;
    [SerializeField] private int _maxFoodCount;

    private FoodPlace[] _foodPlace;
    private Transform _transform;
    private float _startOffsetY;
    private float _currentOffsetY;
    private float _addOffsetY;
    private int _foodPlaceCount;
    private Coroutine _produceFood;

    private void Awake()
    {
        _transform = transform;

        _foodPlaceCount = _transform.GetChild(0).childCount;
        _foodPlace = _transform.GetComponentsInChildren<FoodPlace>();

        _startOffsetY = _foodTemplate.transform.localScale.y;
        _currentOffsetY = _startOffsetY;
        _addOffsetY = _startOffsetY * 2;
    }

    private void OnEnable()
    {
        _produceFood = StartCoroutine(ProduceFood(_timeToGenerate));
    }

    private void OnDisable()
    {
        StopCoroutine(_produceFood);
    }

    private int CountFood()
    {
        int foodCount = 0;

        for (int i = 0; i < _foodPlaceCount; i++)
        {
            foodCount += _foodPlace[i].transform.childCount;
        }

        return foodCount;
    }

    private IEnumerator ProduceFood(float timeToGenerate)
    {
        int foodIndex = 0;

        float jumpPower = 2f;
        int numJumps = 1;
        float jumpDuration = 0.5f;

        var waitForGenerate = new WaitForSecondsRealtime(timeToGenerate);

        _currentOffsetY = _startOffsetY;

        while (Time.timeScale != 0)
        {
            if (CountFood() < _maxFoodCount)
            {
                Food food = Instantiate(_foodTemplate, new Vector3(_transform.position.x, _transform.position.y, _transform.position.z), Quaternion.identity, _foodPlace[foodIndex].transform);

                food.transform.DOJump(new Vector3(_foodPlace[foodIndex].transform.position.x, _foodPlace[foodIndex].transform.position.y + _currentOffsetY, _foodPlace[foodIndex].transform.position.z), jumpPower, numJumps, jumpDuration).SetEase(Ease.OutQuad);

                if (foodIndex < _foodPlaceCount - 1)
                    foodIndex++;
                else
                    foodIndex = 0;

                _currentOffsetY = _startOffsetY + _addOffsetY * _foodPlace[foodIndex].transform.childCount;
            }

            yield return waitForGenerate;
        }
    }
}
