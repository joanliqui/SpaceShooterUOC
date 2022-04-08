using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    #region References
    private InputManager input;
    private Rigidbody rb;
    WeaponManager weaponManager;
    #endregion

    [Header("Ship Movement")]
    [SerializeField] float movSpeed = 10f;
    [SerializeField] float rotationSpeed = 100f;

    //player
    private Vector3 appliedMovement;
    private float targetRotation = 0.0f;



    void Start()
    {
        input = GetComponent<InputManager>();
        rb = GetComponent<Rigidbody>();
        weaponManager = GetComponent<WeaponManager>();
    }

    void Update()
    {
        if (input.shot)
        {
            if (weaponManager.CanShot())
            {
                weaponManager.Shot();
            }
        }

        Movement();
    }

    private void FixedUpdate()
    {
        rb.velocity = appliedMovement;
    }

    private void Movement()
    {
        Vector3 inputDirection = new Vector3(input.moveDir.x, 0f, input.moveDir.y).normalized;
        appliedMovement = inputDirection * movSpeed * Time.deltaTime;
    }

    private void SlightRotation()
    {
        
    }
}
