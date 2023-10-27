using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(CharacterController))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    
    private PlayerInput _playerInput;
    private CharacterController _characterController;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        _playerInput = GetComponent<PlayerInput>();
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        Vector2 inputVector = _playerInput.GetInputVectorNormalized();

        Vector3 moveDirection = new Vector3(inputVector.x, 0, inputVector.y);

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
