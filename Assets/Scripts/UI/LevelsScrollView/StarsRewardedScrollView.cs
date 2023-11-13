using UnityEngine;

public class StarsRewardedScrollView : DynamicScrollView
{
    [SerializeField] private RewardPlayer _reward;

    private void OnEnable()
    {
        FillStarsView();
    }

    public void FillStarsView()
    {
        int length = _reward.GetStars();

        FillView(length);
    }
}
