using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FoodTransition : MonoBehaviour
{
    [SerializeField] private float _transitSpeed = 20f;
    [SerializeField] private float _transitFactor = 0.2f;

    public void TransitFood(List<Food> transitFood, List<Food> stackFood, Vector3 foodPlace)
    {
        if (transitFood.Count > 0) 
        {
            for (int i = 0; i < transitFood.Count; i++)
            {
                Vector3 destination = GetDestination(transitFood, stackFood, foodPlace, i);

                float distance = Vector3.Distance(transitFood[i].transform.position, destination);

                if (distance <= _transitFactor)
                {
                    Food food = transitFood[i];
                    transitFood.Remove(transitFood[i]);
                    stackFood.Add(food);
                }
                else
                {
                    Vector3 direction = destination - transitFood[i].transform.position;

                    transitFood[i].transform.Translate(direction.normalized * _transitSpeed * Time.deltaTime);
                }
            }
        }
    }

    private Vector3 GetDestination(List<Food> transitFood, List<Food> stackFood, Vector3 foodPlace, int currentIndex)
    {
        Vector3 destination = new Vector3();

        int stackCount = stackFood.Count;
        float offsetY = transitFood[0].transform.localScale.y;

        if (stackCount == 0 && currentIndex == 0)
            destination = foodPlace;
        else if (stackCount == 0)
            destination = new Vector3(foodPlace.x, foodPlace.y + offsetY * currentIndex, foodPlace.z);
        else if (transitFood.Count == 0)
            destination = new Vector3(stackFood.Last().transform.position.x, stackFood.Last().transform.position.y + offsetY, stackFood.Last().transform.position.z);
        else
            destination = new Vector3(stackFood.Last().transform.position.x, stackFood.Last().transform.position.y + offsetY * (currentIndex + 1), stackFood.Last().transform.position.z);

        return destination;
    }
}
