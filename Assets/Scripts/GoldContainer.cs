using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GoldContainer : MonoBehaviour
{
    private GoldPlace[] _goldPlaces;
    private int _goldPlaceCount;

    public int GoldPlaceCount => _goldPlaceCount;

    private void Awake()
    {
        _goldPlaces = GetComponentsInChildren<GoldPlace>();
        _goldPlaceCount = _goldPlaces.Length;
    }

    public int CountGold()
    {
        return GetComponentsInChildren<Gold>().Length;
    }

    public GoldPlace GetGoldPlaceByIndex(int index)
    {
        return _goldPlaces[index];
    }

    private GoldPlace FindMaxStack()
    {
        int maxGoldCount = 0;
        GoldPlace maxGoldPlace = null;

        foreach (var goldPlace in _goldPlaces)
        {
            if (goldPlace.transform.childCount > maxGoldCount)
            {
                maxGoldCount = goldPlace.transform.childCount;
                maxGoldPlace = goldPlace;
            }
        }

        return maxGoldPlace;
    }

    private Gold FindTopGoldInMaxStack()
    {
        GoldPlace maxGoldPlace = FindMaxStack();

        Gold gold = null;

        if (maxGoldPlace != null)
        {
            Gold[] allGold = maxGoldPlace.transform.GetComponentsInChildren<Gold>();
            gold = allGold.Last();
        }

        return gold;
    }
}
