using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    #region References
    private InputManager input;
    private Rigidbody rb;
    #endregion

    [SerializeField] float movSpeed = 10f;
    private Vector2 appliedMovement;

    [SerializeField] float timeBtwShots = 0.2f;
    private float cntTimeBtwShots = 0f;
    void Start()
    {
        input = GetComponent<InputManager>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (input.shot)
        {
            if (CanShot())
            {
                Shot();
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
        Vector3 inputDirection = new Vector3(input.moveDir.x, input.moveDir.y, 0f).normalized;
        appliedMovement = inputDirection * movSpeed * Time.deltaTime;
    }

    private bool CanShot()
    {
        bool canShot = true;
        if(cntTimeBtwShots > 0)
        {
            cntTimeBtwShots -= Time.deltaTime;
            canShot = false;
        }
        else
        {
            cntTimeBtwShots = timeBtwShots;
            canShot = true;
        }

        return canShot;
    }

    private void Shot()
    {
        Debug.Log("Shot");
    }
}
