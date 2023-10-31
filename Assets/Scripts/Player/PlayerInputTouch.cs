using UnityEngine;

public class PlayerInputTouch : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;

    private void Awake()
    {
        if (Application.isMobilePlatform)
            _joystick.gameObject.SetActive(true);
    }

    public Vector2 GetInputVectorNormalized()
    {
        return _joystick.Direction.normalized;
    }
}
