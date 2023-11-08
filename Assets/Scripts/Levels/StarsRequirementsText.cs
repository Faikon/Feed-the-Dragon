using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StarsRequirementsText : MonoBehaviour
{
    [SerializeField] private StarsRequirements _starsRequirements;
    [SerializeField] private List<TMP_Text> _starsRequirementsText;

    private void OnEnable()
    {
        for (int i = 0; i < _starsRequirements.GetStarsCount(); i++)
        {
            _starsRequirementsText[i].text = TimeFormat.FormatTime(_starsRequirements.GetStarRequirementByIndex(i));
        }
    }
}
