using UnityEngine;

public class MoveTutorial : MonoBehaviour
{
    [SerializeField] GameObject _touchTutorial;
    [SerializeField] GameObject _keyboardTutorial;

    private void Start()
    {
        if (UnityEngine.Device.Application.isMobilePlatform)
        {
            _touchTutorial.SetActive(true);
        }
        else
        {
            _keyboardTutorial.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _touchTutorial.SetActive(false);
        _keyboardTutorial.SetActive(false);
    }
}
