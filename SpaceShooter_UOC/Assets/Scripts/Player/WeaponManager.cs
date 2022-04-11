using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] Weapon initialWeapon;
    private Weapon selectedWeapon;
    private int selectWeaponNum = 0;

    [SerializeField] Transform[] weaponSockets = new Transform[2];

    private List<Weapon> weapons = new List<Weapon>();
    private WeaponUI weaponUI;

    private AudioSource source;

    private float cntTimeBtwShots = 0;


    private void Start()
    {
        weaponUI = GameObject.FindGameObjectWithTag("WeaponUI").GetComponent<WeaponUI>();
        source = GetComponent<AudioSource>();

        if(initialWeapon != null)
        {
            weaponUI.InicializeWeaponHolderUI(initialWeapon);
            weapons.Add(initialWeapon);
            selectedWeapon = initialWeapon;

            InstantiateConcreteWeapon(initialWeapon);
        }
        
    }

    public void Shot()
    {
        selectedWeapon.Shot(weaponSockets, source);
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
        //Si el arma NO esta en la lista la a�adimos y actualizamos la UI
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

    private void InstantiateConcreteWeapon(Weapon wp)
    {
        if(wp != null)
        {
            GameObject w = Instantiate(wp.gameObject, weaponSockets[0].position, Quaternion.Euler(0.0f, 90f, 0.0f), weaponSockets[0]);
            
        }
    }
}
