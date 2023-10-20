using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speedMultiplier;
    [SerializeField] private float maxVelocity = 5;

    private Rigidbody2D _playerRigidbody;
    
    private float _upwardForce = 2f;
    private Vector2 _movementVector;
    private bool _isForceApplied;

    private void Start()
    {
        _playerRigidbody = GetComponentInChildren<Rigidbody2D>();
    }

    #region PlayerInputs
    
    private void OnTouchInput(InputValue value)
    {
        if (value.Get<float>()>0.5f)
        {
            _isForceApplied = true;
        }
    }

    private void OnTouchPosition(InputValue value)
    {
        GetMovementVector(value.Get<Vector2>());
    }
    #endregion
    
    private void FixedUpdate()
    {
        if (_isForceApplied)
        {
            _playerRigidbody.velocity = _movementVector * (speedMultiplier * Time.fixedDeltaTime);
            _isForceApplied = false;
        }
        
        ConstrainUpwardVelocity();
    }

    private void GetMovementVector(Vector2 touchPosition)
    {
        Vector2 touchKiWorldPosition = Camera.main.ScreenToWorldPoint(touchPosition);
        _movementVector = new Vector2(touchKiWorldPosition.x - _playerRigidbody.position.x, _upwardForce);
        _movementVector.Normalize();
    }

    private void ConstrainUpwardVelocity()
    {
        if (_playerRigidbody.velocity.y > 0)
        {
            float limitedSpeed = Mathf.Clamp(_playerRigidbody.velocity.magnitude, 0f, maxVelocity);
            _playerRigidbody.velocity = _playerRigidbody.velocity.normalized * limitedSpeed;
        }
    }
    
}









/*
    [SerializeField] private float xMin = -2.5f;
    [SerializeField] private float xMax = 2.5f;
    [SerializeField] private float yMin = -5f;
    
 private void RestrictPlayerMovement()
{
    Vector2 playerPosition = transform.position;
    playerPosition.x = Mathf.Clamp(playerPosition.x, xMin, xMax);
    playerPosition.y = Mathf.Clamp(playerPosition.y, yMin, Mathf.Infinity);
    transform.position = playerPosition;
}*/