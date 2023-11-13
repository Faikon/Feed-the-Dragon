using UnityEngine;
using UnityEngine.UI;

public class LevelsScrollView : DynamicScrollView
{
    private int _levelsCompleted;
    private float _targetImageAlpha = 0.5f;

    private void Awake()
    {
        _levelsCompleted = PlayerPrefs.GetInt(PlayerKeys.LevelsCompleted.ToString());
    }

    private void OnEnable()
    {
        FillView(GetContentLength(), _levelsCompleted + 1, _targetImageAlpha);

        EnableButtons();
    }

    private int GetContentLength()
    {
        return _scrollViewContent.childCount;
    }

    private void EnableButtons()
    {
        for (int i = 0; i < _levelsCompleted + 1; i++)
        {
            ScrollViewItem scrollViewItem = _scrollViewContent.GetChild(i).GetComponent<ScrollViewItem>();
            scrollViewItem.GetComponent<Button>().interactable = true;
        }
    }
}
