using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class GoldDeliveryAreaView : DeliveryAreaView
{
    [SerializeField] Image _fillImage;
    [SerializeField] private float _pingPongHalfScaleDuration = 0.5f;
    [SerializeField] private Vector3 _pingPongScaleAddition = new Vector3(0.2f, 0.2f, 0);

    private GoldDeliveryArea _goldDeliveryArea;
    private Canvas _canvas;
    private Transform _canvasTransform;
    private Coroutine _pingPongScale;
    private Vector3 _originalScale;
    private Vector3 _pingPongDesiredScale;
    private float _pingPongScaleDuration;

    protected override void Awake()
    {
        base.Awake();

        _goldDeliveryArea = GetComponentInParent<GoldDeliveryArea>();
        _canvas = GetComponentInChildren<Canvas>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        _goldDeliveryArea.GoldDelivering += OnGoldDelivering;
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        _goldDeliveryArea.GoldDelivering -= OnGoldDelivering;
    }

    private void Start()
    {
        _canvasTransform = _canvas.transform;
        _originalScale = _canvasTransform.localScale;
        _pingPongDesiredScale = _originalScale + _pingPongScaleAddition;
        _pingPongScaleDuration = _pingPongHalfScaleDuration * 2f;
    }

    protected override void OnDelivering(bool isDelivering)
    {
        if (isDelivering)
        {
            _pingPongScale = StartCoroutine(PingPongScale(isDelivering));
        }
        else
        {
            StopCoroutine(_pingPongScale);
        }
    }

    private void OnGoldDelivering(int currentGoldToDelive, int goldToDelive)
    {
        _fillImage.fillAmount = (float)currentGoldToDelive / goldToDelive;
    }

    private IEnumerator PingPongScale(bool isDelivering)
    {
        while (isDelivering)
        {
            _canvasTransform.DOScale(_pingPongDesiredScale, _pingPongHalfScaleDuration).SetEase(Ease.InOutSine).OnComplete(() =>
            {
                _canvasTransform.DOScale(_originalScale, _pingPongHalfScaleDuration).SetEase(Ease.OutBounce);
            });

            yield return new WaitForSecondsRealtime(_pingPongScaleDuration);
        }
    }
}