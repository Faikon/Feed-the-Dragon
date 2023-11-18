using UnityEngine;

public class RemoveObstacleArea : GoldDeliveryArea
{
    [SerializeField] Transform _obstacle;

    private void OnEnable()
    {
        GoldDelivered += RemoveObstacle;
    }

    private void OnDisable()
    {
        GoldDelivered -= RemoveObstacle;
    }

    private void RemoveObstacle()
    {
        _obstacle.gameObject.SetActive(false);
    }
}
