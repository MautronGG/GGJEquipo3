using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputExploration : MonoBehaviour
{
    PlayerInput _playerInput;
    InputAction _movementAction;
    Vector2 _position;
    Vector3 _look;
    [SerializeField] int _velocity;

    // Start is called before the first frame update
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _movementAction = _playerInput.actions.FindAction("Movement");
    }

    // Update is called once per frame
    void Update()
    {
        _look = Camera.main.transform.forward;
        _look.y = 0;
        transform.forward = _look.normalized;
        _position = _movementAction.ReadValue<Vector2>();
        transform.position += _position.y * _velocity * Time.deltaTime * transform.forward;
        transform.position += _position.x * _velocity * Time.deltaTime * transform.right;
        //transform.position += new Vector3(_position.x, 0, _position.y) * _velocity * Time.deltaTime;
    }
}
