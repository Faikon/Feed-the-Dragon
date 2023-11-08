using System.Collections.Generic;
using UnityEngine;

public class StarsRequirements : MonoBehaviour
{
    [SerializeField] private List<float> _starsRequirements;

    public float GetStarRequirementByIndex(int index)
    {
        return _starsRequirements[index];
    }

    public int GetStarsCount()
    {
        return _starsRequirements.Count;
    }
}
