using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUI : MonoBehaviour
{
    [SerializeField] List<WeaponUIHolder> holders = new List<WeaponUIHolder>();

    //Resetea todos los holders y a�ade al primer holder un arma
    public void InicializeWeaponHolderUI(Weapon firstWeapon)
    {
        foreach (Transform item in transform)
        {
            holders.Add(item.GetComponent<WeaponUIHolder>());
        }

        foreach (WeaponUIHolder item in holders)
        {
            item.SwitchWeaponImage(null);
            item.IsEmpty = true;
        }

        holders[0].IsEmpty = false;
        holders[0].SwitchWeaponImage(firstWeapon.WeaponSprite);
    }
    public void InsertNewWeaponInEmptyHolder(Weapon wp)
    {
        foreach (WeaponUIHolder item in holders)
        {
            if (item.IsEmpty)
            {
                item.IsEmpty = false;
                item.SwitchWeaponImage(wp.WeaponSprite);
                break;
            }
        }
    }

    public void SetSelectedWeaponUI(int holderNumber)
    {

    }

    public void UpgradeWeaponUI(Weapon wp)
    {
        Debug.Log("Weapon Upgraded!");
    }
}
