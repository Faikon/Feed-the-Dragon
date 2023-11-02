using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private Pointer _nextPointer;
    [SerializeField] private float _activationDelay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            Invoke(nameof(ActivateNextPointer), _activationDelay);
        }
    }

    private void ActivateNextPointer()
    {
        if (_nextPointer != null)
        {
            _nextPointer.gameObject.SetActive(true);
        }

        gameObject.SetActive(false);
    }
}
