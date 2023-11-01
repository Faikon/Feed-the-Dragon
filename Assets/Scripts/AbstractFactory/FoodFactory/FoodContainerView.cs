using TMPro;
using UnityEngine;

public class FoodContainerView : MonoBehaviour
{
    [SerializeField] private TMP_Text _maxText;

    private FoodFactory _foodFactory;

    private void Awake()
    {
        _foodFactory = GetComponentInParent<FoodFactory>();
    }

    private void OnEnable()
    {
        _foodFactory.IsWorking += OnWorking;
    }

    private void OnDisable()
    {
        _foodFactory.IsWorking -= OnWorking;
    }

    private void OnWorking(bool isWorking)
    {
        if (isWorking)
        {
            _maxText.gameObject.SetActive(false);
        }
        else
        {
            _maxText.gameObject.SetActive(true);
        }
    }
}
