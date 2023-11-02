using UnityEngine;

[RequireComponent(typeof(PlayerInputKeyboard))]
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInputTouch))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private Animator _animator;

    private string _isMovingParameterHash = "isMoving";
    private PlayerInputKeyboard _playerInputKeyboard;
    private PlayerInputTouch _playerInputTouch;
    private CharacterController _characterController;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        _playerInputKeyboard = GetComponent<PlayerInputKeyboard>();
        _characterController = GetComponent<CharacterController>();
        _playerInputTouch = GetComponent<PlayerInputTouch>();
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        Vector2 inputVector = Vector2.zero;

        if (Application.isMobilePlatform)
            inputVector = _playerInputTouch.GetInputVectorNormalized();
        else
            inputVector = _playerInputKeyboard.GetInputVectorNormalized();

        Vector3 moveDirection = new Vector3(inputVector.x, 0, inputVector.y);

        if (moveDirection == Vector3.zero)
            _animator.SetBool(_isMovingParameterHash, false);
        else
            _animator.SetBool(_isMovingParameterHash, true);

        if (_characterController.isGrounded)
        {
            _characterController.Move(moveDirection * _moveSpeed * Time.deltaTime + Vector3.down);
            _transform.forward = Vector3.Slerp(_transform.forward, moveDirection, Time.deltaTime * _rotateSpeed);
        }
        else
        {
            _characterController.Move(_characterController.velocity + Physics.gravity * Time.deltaTime);
        }
    }
}
