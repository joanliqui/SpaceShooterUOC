using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] Weapon initialWeapon;
    private Weapon selectedWeapon;
    private int selectWeaponNum = 0;

    [SerializeField] Transform[] weaponSockets = new Transform[2];
    [SerializeField] Transform arsenal;

    private List<Weapon> weapons = new List<Weapon>();
    private WeaponUI weaponUI;

    private AudioSource source;

    private float cntTimeBtwShots = 0;
    private bool canShot = true;


    private void Start()
    {
        weaponUI = GameObject.FindGameObjectWithTag("WeaponUI").GetComponent<WeaponUI>();
        source = GetComponent<AudioSource>();

        if(initialWeapon != null)
        {
            weaponUI.InicializeWeaponHolderUI(initialWeapon);
            InicializeFirstWeapon();

        }
        
    }

    private void InicializeFirstWeapon()
    {
        InstantiateConcreteWeapon(initialWeapon);
        weapons.Add(InstantiateConcreteWeaponObject(initialWeapon));
        selectedWeapon = initialWeapon;
        Debug.Log("FirstSelectedWeapon:" + selectedWeapon.name);
    }

    private Weapon InstantiateConcreteWeaponObject(Weapon wp)
    {
        GameObject w = Instantiate(wp.gameObject, arsenal);
        w.name = "Concrete" + wp.name;
        if (w.TryGetComponent(out Weapon p))
        {
            return p;
        }
        else
        {
            Debug.LogWarning("No se puedo encontrar una Wapon en el objeto");
            return null;
        }
    }

    public void Shot()
    {
        cntTimeBtwShots = selectedWeapon.TimeBtwShots;
        canShot = false;
        if(selectedWeapon != null)
            selectedWeapon.Shot(weaponSockets, source);

    }
    public bool CanShot()
    {
        if (!canShot)
        {
            if (cntTimeBtwShots >= 0.01f)
            {
                cntTimeBtwShots -= Time.deltaTime;
                canShot = false;
            }
            else
            {
                canShot = true;
            }
        }

        return canShot;
    }
    public void AddWeapon(Weapon wp)
    {
        //Si el arma NO esta en la lista la añadimos y actualizamos la UI
        if (!CheckIfWeaponExist(wp))
        {
            weapons.Add(InstantiateConcreteWeaponObject(wp));
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

        weaponUI.SetSelectedWeaponUI(selectWeaponNum);
    }

    private void InstantiateConcreteWeapon(Weapon wp)
    {
        if(wp != null)
        {
            GameObject w = Instantiate(wp.gameObject, weaponSockets[0].position, Quaternion.Euler(0.0f, 90f, 0.0f), weaponSockets[0]);
            
        }
    }
}
