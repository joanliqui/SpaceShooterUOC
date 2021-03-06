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
    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] float maxRotation = 25f;
#if UNITY_EDITOR
    [SerializeField] float editorMovMultiplier = 2;
#endif

    //player
    private Vector3 appliedMovement;
    private Vector3 initialRotation;
    private float rotationVelocity;
    float targetRotation = 0.0f;
    public float elapsed;




    void Start()
    {
        if(input == null)
            input = GetComponent<InputManager>();
        if(rb == null)
            rb = GetComponent<Rigidbody>();
        if(weaponManager == null)
            weaponManager = GetComponent<WeaponManager>();

        initialRotation = transform.localEulerAngles;
    }

    void Update()
    {
        if (weaponManager.CanShot())
        {
            if (input.shot)
            {
                weaponManager.Shot();

            }
        }

        Movement();
        //SlightRotation();
    }

    private void FixedUpdate()
    {
        rb.velocity = appliedMovement;
    }

    private void Movement()
    {
        Vector3 inputDirection = new Vector3(-input.moveDir.y, 0f, input.moveDir.x).normalized;
#if UNITY_EDITOR
        inputDirection *= editorMovMultiplier;
#endif
        appliedMovement = inputDirection * movSpeed * Time.deltaTime;
    }

    private void SlightRotation()
    {
        /*
        float roll = 0;
        if(input.moveDir.y != 0)
        {
            roll = rotationSpeed * Time.deltaTime * input.moveDir.y;
            if(Mathf.Abs(transform.localEulerAngles.z) > maxRotation)
            {
                transform.Rotate(0f, 0f, roll);
            }
        }
        else
        {
            if(transform.localEulerAngles.z > 0.1 || transform.localEulerAngles.z < -0.1)
            {
                transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, Vector3.zero, rotationSpeed + elapsed);
                delta += Time.deltaTime;
            }
            else
            {
                transform.localEulerAngles = initialRotation;
            }
        }    
        */
        if(input.moveDir.y != 0)
        {
            targetRotation = Mathf.Atan2(input.moveDir.x, input.moveDir.y) * Mathf.Rad2Deg;
            float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.z, targetRotation, ref rotationVelocity, rotationSpeed);

            transform.rotation = Quaternion.Euler(0.0f, 90f, rotation); 
        }
        else
        {
            transform.localEulerAngles = initialRotation;
        }

    }
}
