using System.Collections.Generic;
using UnityEngine;

public class LevelRewards : MonoBehaviour
{
    [SerializeField] private List<int> _levelRewards;

    public int GetRewardByIndex(int index)
    {
        return _levelRewards[index];
    }
}
