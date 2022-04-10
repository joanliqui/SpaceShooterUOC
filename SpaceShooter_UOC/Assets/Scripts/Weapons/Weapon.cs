using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected float timeBtwShots = 0.1f;
    [SerializeField] protected Sprite weaponSprite;
    
    protected int weaponLvl = 1;
    protected int maxWeaponLvl = 3;

    public Sprite WeaponSprite { get => weaponSprite;}
    public float TimeBtwShots { get => timeBtwShots; set => timeBtwShots = value; }

    public abstract void Shot(Transform socket);

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<WeaponManager>(out WeaponManager wm))
        {
            wm.AddWeapon(this);
        }
    }
}