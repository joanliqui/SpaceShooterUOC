using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPowerUp : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
  

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
