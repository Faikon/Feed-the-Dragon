using UnityEngine;

public abstract class DynamicScrollView : MonoBehaviour
{
    [SerializeField] protected Transform _scrollViewContent;

    [SerializeField] private Sprite _changedImage;

    protected void FillView(int contentLenght, int startElement = 0, float alpha = 1)
    {
        for (int i = startElement; i < contentLenght; i++)
        {
            ScrollViewItem scrollViewItem = _scrollViewContent.GetChild(i).GetComponent< ScrollViewItem>();
            scrollViewItem.ChangeImage(_changedImage);
            scrollViewItem.ChangeAlpha(alpha);
        }
    }
}
