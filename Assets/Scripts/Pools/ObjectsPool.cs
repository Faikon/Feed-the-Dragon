using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectsPool : MonoBehaviour
{
    [SerializeField] protected GameObject _prefab;
    [SerializeField] private int _preloadCount;

    private Queue<GameObject> _pool = new Queue<GameObject>();
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        Initialize(_prefab);
    }

    public void Initialize(GameObject prefab)
    {
        for (int i = 0; i < _preloadCount; i++)
            Return(Preload(prefab));
    }

    public GameObject Get()
    {
        GameObject item = _pool.Count > 0 ? _pool.Dequeue() : Preload(_prefab);

        item.SetActive(true);

        return item;
    }

    public void Return(GameObject item)
    {
        item.SetActive(false);

        item.transform.parent = _transform;

        _pool.Enqueue(item);
    }

    private GameObject Preload(GameObject prefab) => UnityEngine.Object.Instantiate(prefab, _transform);
}
