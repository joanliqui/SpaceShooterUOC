using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    private PlayerControls _input;
    [Header("Input values")]
    public Vector2 moveDir;
    public bool shot;

    
    [SerializeField] UnityEvent onSwitchWeaponClick;
    private void Awake()
    {
        if(_input == null)
            _input = new PlayerControls();

        _input.Ship.Move.performed += onMove;
        _input.Ship.Move.canceled += onMove;

        _input.Ship.Shot.performed += onShot;
        _input.Ship.Shot.canceled += onShot;

        _input.Ship.SwitchWeapon.canceled += onSwitchWeapon;

    }

    private void onSwitchWeapon(InputAction.CallbackContext obj)
    {
        onSwitchWeaponClick?.Invoke();
    }

    private void onShot(InputAction.CallbackContext obj)
    {
        shot = obj.ReadValueAsButton();
    }

    private void onMove(InputAction.CallbackContext obj)
    {
        moveDir = obj.ReadValue<Vector2>();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Ship.Shot.performed -= onShot;
        _input.Ship.Shot.canceled += onShot;
        _input.Disable();
    }
}
