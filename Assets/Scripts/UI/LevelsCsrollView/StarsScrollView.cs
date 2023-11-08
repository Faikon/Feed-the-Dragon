using UnityEngine;

public class StarsScrollView : DynamicScrollView
{
    [SerializeField] private PlayerKeys _levelStarsKey;

    private void OnEnable()
    {
        FillStarsView();
    }

    public void FillStarsView()
    {
        FillView(PlayerPrefs.GetInt(_levelStarsKey.ToString()));
    }
}
