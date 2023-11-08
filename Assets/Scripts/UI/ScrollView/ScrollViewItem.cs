using UnityEngine;
using UnityEngine.UI;

public class ScrollViewItem : MonoBehaviour
{
    [SerializeField] private Image _childImage;
    
    public void ChangeImage(Sprite image)
    {
        _childImage.sprite = image;
    }

    public void ChangeAlpha(float alpha)
    {
        Color color = _childImage.color;
        color.a = alpha;
        _childImage.color = color;
    }
}
