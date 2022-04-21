using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPowerUp : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private int movSpeed = 10;

    private void Update()
    {
        transform.Translate(Vector3.back * movSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (weapon)
            {
                WeaponManager wm = other.GetComponent<WeaponManager>();
                wm.AddWeapon(weapon);
                gameObject.SetActive(false);
            }

        }
    }
}
