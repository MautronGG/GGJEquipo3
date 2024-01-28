using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputExploration : MonoBehaviour
{
    [SerializeField] PlayerInventory _inventory;
    [SerializeField] Transform _canvas;
    PlayerInput _playerInput;
    InputAction _movementAction;
    Transform _transform;
    Vector2 _position;
    Vector3 _look;
    [SerializeField] Camera _camera;
    [SerializeField] int _velocity;
  //[SerializeField] Transform _canvas;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _transform = transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        _movementAction = _playerInput.actions.FindAction("Movement");
    }

    private void OnEnable()
    {
        _playerInput.actions["Interact"].performed += OnInteraction;
    }

    private void OnDisable()
    {
        _playerInput.actions["Interact"].performed -= OnInteraction;
    }

    // Update is called once per frame
    void Update()
    {
        _look = _camera.transform.forward;
        _look.y = 0;
        transform.forward = _look.normalized;
        _position = _movementAction.ReadValue<Vector2>();
        transform.position += _position.y * _velocity * Time.deltaTime * transform.forward;
        transform.position += _position.x * _velocity * Time.deltaTime * transform.right;
    }

    /// <summary>
    /// Cuendo se presiona "E", se llama la funcion para intentar interactuar con un objeto
    /// </summary>
    /// <param name="callbackContext"></param>
    private void OnInteraction(InputAction.CallbackContext callbackContext)
    {
        // Si no golpea nada, termina la funcion
        if (!Physics.Raycast(_transform.position + (Vector3.up * 0.3f) + (_transform.forward * 0.2f),
            _transform.forward, out var hit, 1.5f)) 
        {
            return;
        }
        
        // Si el objeto golpeado no contiente "InteractableObject", se termina la funcion
        if (!hit.transform.TryGetComponent(out InteractableObject interactable)){
            return;
        }
        _inventory.AddToArray(_inventory.m_memeCardsArray, interactable.Interact(_canvas));
    }
}
