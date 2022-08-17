using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ContestantController : MonoBehaviour
{
    [SerializeField] protected float DefaultMovementSpeed;

    protected bool _isMoving = false;
    protected float _movementSpeed;
    protected bool _ignoreInput = false;
    protected GameObject _player;

    protected void Start()
    {
        InputManager.OnPointerDown.AddListener(OnPointerDown);
        InputManager.OnPointerUp.AddListener(OnPointerUp);

        _movementSpeed = DefaultMovementSpeed;
        _player = FindObjectOfType<MovementController>().gameObject;
    }
    protected void OnDestroy()
    {
        InputManager.OnPointerDown.RemoveListener(OnPointerDown);
        InputManager.OnPointerUp.RemoveListener(OnPointerUp);
    }

    protected void OnPointerDown()
    {
        if (_ignoreInput)
            return;

        _isMoving = true;
    }
    protected void OnPointerUp()
    {
        if (_ignoreInput)
            return;

        _isMoving = false;
    }

    protected void FixedUpdate()
    {
        if (_isMoving)
        {
            Move();

            float distance = _player.transform.position.z - transform.position.z;
            if (distance > 15)
                _movementSpeed = DefaultMovementSpeed * 3f;
            else if (distance < -5)
                _movementSpeed = DefaultMovementSpeed / 3f;
            else
                _movementSpeed = DefaultMovementSpeed;
        }
    }

    public void Finished()
    {
        _isMoving = false;
        _ignoreInput = true;
    }

    protected abstract void Move();
}
