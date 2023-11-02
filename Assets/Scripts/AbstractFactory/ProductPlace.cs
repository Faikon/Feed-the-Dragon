using DG.Tweening;
using System.Collections;
using System.Linq;
using UnityEngine;

public abstract class ProductPlace: MonoBehaviour
{
    private Transform _transform;
    private bool _isRecieving;

    private void Awake()
    {
        _isRecieving = false;
        _transform = transform;
    }

    public virtual float GetCurrentOffsetY(Product product)
    {
        return product.transform.localScale.y * _transform.childCount;
    }

    public virtual Product GetTopProduct()
    {
        int childCount = _transform.childCount;

        if (childCount > 0 && _isRecieving == false)
        {
            Transform lastChild = _transform.GetChild(childCount - 1);
            return lastChild.GetComponent<Product>();
        }

        return null;
    }

    public virtual void RecieveProduct(Product product, float timeToCreate)
    {
        _isRecieving = true;

        float offsetY = GetCurrentOffsetY(product);

        float jumpPower = 4f;
        int numJumps = 1;
        float jumpDuration = 0.7f;

        if (jumpDuration > timeToCreate)
            jumpDuration = timeToCreate;

        Tween productJump = product.transform.DOJump(new Vector3(_transform.position.x, _transform.position.y + offsetY, _transform.position.z), jumpPower, numJumps, jumpDuration).SetEase(Ease.OutQuad).OnComplete(() =>
        {
            _isRecieving = false;
            product.transform.SetParent(_transform);
        });
    }
}
