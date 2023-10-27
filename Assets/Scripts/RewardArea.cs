using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class RewardArea : MonoBehaviour
{
    [SerializeField] private Gold _goldTemplate;
    [SerializeField] private int goldViewPerGold = 5;
    [SerializeField] private float _timeToGenerate;

    private Transform _transform;
    private float _startOffsetY;
    private float _currentOffsetY;
    private float _addOffsetY;
    private Coroutine _produceGold;
    private GoldContainer _goldContainer;

    private void Awake()
    {
        _transform = transform;

        _goldContainer = GetComponentInChildren<GoldContainer>();

        _startOffsetY = _goldTemplate.transform.localScale.y;
        _currentOffsetY = _startOffsetY;
        _addOffsetY = _startOffsetY * 2;
    }

    public int Gold { get; private set; }

    public void AddGold(int gold)
    {
        if (gold > 0)
            Gold += gold;

        _produceGold = StartCoroutine(ProduceGold(_timeToGenerate, gold));
    }

    private IEnumerator ProduceGold(float timeToGenerate, int addedGold)
    {
        int goldIndex = 0;

        float jumpPower = 2f;
        int numJumps = 1;
        float jumpDuration = 0.5f;

        var waitForGenerate = new WaitForSecondsRealtime(timeToGenerate);

        _currentOffsetY = _startOffsetY;

        while (true)
        {
            if (addedGold / goldViewPerGold > 0)
            {
                GoldPlace goldPlace = _goldContainer.GetGoldPlaceByIndex(goldIndex);
                Gold gold = Instantiate(_goldTemplate, new Vector3(_transform.position.x, _transform.position.y, _transform.position.z), Quaternion.identity, goldPlace.transform);
                gold.transform.DOJump(new Vector3(goldPlace.transform.position.x, goldPlace.transform.position.y + _currentOffsetY, goldPlace.transform.position.z), jumpPower, numJumps, jumpDuration).SetEase(Ease.OutQuad);

                if (goldIndex < _goldContainer.GoldPlaceCount - 1)
                    goldIndex++;
                else
                    goldIndex = 0;

                goldPlace = _goldContainer.GetGoldPlaceByIndex(goldIndex);
                _currentOffsetY = _startOffsetY + _addOffsetY * goldPlace.transform.childCount;

                addedGold -= goldViewPerGold;
            }

            yield return waitForGenerate;
        }
    }

}
