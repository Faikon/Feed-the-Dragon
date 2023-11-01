using UnityEngine;

public abstract class DeliveryAreaView : MonoBehaviour
{
    [SerializeField] private float _scaleChangeX;
    [SerializeField] private float _scaleChangeZ;

    private DeliveryArea _deliveryArea;
    private Vector3 _scaleChange;
    private Transform _transform;

    protected virtual void Awake()
    {
        _transform = transform;
        _scaleChange = new Vector3(_scaleChangeX, 0, _scaleChangeZ);
        _deliveryArea = GetComponentInParent<DeliveryArea>();
    }

    protected virtual void OnEnable()
    {
        _deliveryArea.IsDelivering += OnDelivering;
    }

    protected virtual void OnDisable()
    {
        _deliveryArea.IsDelivering -= OnDelivering;
    }

    protected virtual void OnDelivering(bool isDelivering)
    {
        if (isDelivering)
        {
            _transform.localScale += _scaleChange;
        }
        else
        {
            _transform.localScale -= _scaleChange;
        }
    }
}