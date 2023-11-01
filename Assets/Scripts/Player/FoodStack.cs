using System.Collections.Generic;
using UnityEngine;

public class FoodStack : MonoBehaviour
{
    [SerializeField] private float _followSpeed = 35f;

    public void MoveStackFood(List<Food> stackFood, Transform foodPlace)
    {
        for (int i = 0; i < stackFood.Count; i++)
        {
            if (i == 0)
                MoveStackItems(foodPlace, stackFood[i].transform);
            else
                MoveStackItems(stackFood[i - 1].transform, stackFood[i].transform);
        }
    }

    private void MoveStackItems(Transform firstItem, Transform secondItem)
    {
        float offsetY = firstItem.localScale.y / 2 + secondItem.localScale.y / 2;

        secondItem.position = new Vector3(Mathf.Lerp(secondItem.position.x, firstItem.position.x, Time.deltaTime * _followSpeed),
                    Mathf.Lerp(secondItem.position.y, firstItem.position.y + offsetY, Time.deltaTime * _followSpeed), firstItem.position.z);
    }
}
