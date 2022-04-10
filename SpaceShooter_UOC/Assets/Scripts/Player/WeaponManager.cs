using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] Weapon initialWeapon;
    private Weapon selectedWeapon;
    private int selectWeaponNum = 0;

    [SerializeField] Transform weaponSocket;

    private List<Weapon> weapons = new List<Weapon>();
    private WeaponUI weaponUI;


    private float cntTimeBtwShots = 0;

    public Weapon SelectedWeapon { get => selectedWeapon; set => selectedWeapon = value; }

    private void Start()
    {
        weaponUI = GameObject.FindGameObjectWithTag("WeaponUI").GetComponent<WeaponUI>();
        if(initialWeapon != null)
        {
            weaponUI.InicializeWeaponHolderUI(initialWeapon);
            weapons.Add(initialWeapon);
            selectedWeapon = initialWeapon;
        }
        
    }

    public void Shot()
    {
        selectedWeapon.Shot(weaponSocket);
    }
    public bool CanShot()
    {
        bool canShot = true;
        if (cntTimeBtwShots > 0.01f)
        {
            cntTimeBtwShots -= Time.deltaTime;
            canShot = false;
        }
        else
        {
            cntTimeBtwShots = selectedWeapon.TimeBtwShots;
            canShot = true;
        }

        return canShot;
    }
    public void AddWeapon(Weapon wp)
    {
        //Si el arma NO esta en la lista la añadimos y actualizamos la UI
        if (!CheckIfWeaponExist(wp))
        {
            weapons.Add(wp);
            weaponUI.InsertNewWeaponInEmptyHolder(wp);
        }
        else
        {
            weaponUI.UpgradeWeaponUI(wp);
        }
    }
    private bool CheckIfWeaponExist(Weapon wp)
    {
        return weapons.Contains(wp);
    }

    public void SwitchSelectedWeapon()
    {
        selectWeaponNum++;
        if(selectWeaponNum >= weapons.Count)
        {
            selectWeaponNum = 0;
        }
        Debug.Log(selectWeaponNum);
        selectedWeapon = weapons[selectWeaponNum];
    }
}
