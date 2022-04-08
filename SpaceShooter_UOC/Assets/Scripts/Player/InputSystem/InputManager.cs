using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerControls _input;
    [Header("Input values")]
    public Vector2 moveDir;
    public bool shot;

    
    private void Awake()
    {
        _input = new PlayerControls();
        _input.Ship.Move.performed += onMove;
        _input.Ship.Move.canceled += onMove;

        _input.Ship.Shot.performed += onShot;
        _input.Ship.Shot.canceled += onShot;

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
}
