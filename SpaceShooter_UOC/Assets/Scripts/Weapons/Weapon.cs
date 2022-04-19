using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    //[SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected float timeBtwShots = 0.1f;
    [SerializeField] protected Sprite weaponSprite;
    [SerializeField] protected int damage;
    [SerializeField] protected Pool bulletPool;
    [SerializeField] protected AudioClip clip;

    protected int weaponLvl = 1;
    protected int maxWeaponLvl = 3;
    public Sprite WeaponSprite { get => weaponSprite;}
    public float TimeBtwShots { get => timeBtwShots; set => timeBtwShots = value; }
    public int Damage { get => damage; set => damage = value; }


    public virtual void Shot(Transform socket, AudioSource source)
    {

    }
    public virtual void Shot(Transform[] socket, AudioSource source)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<WeaponManager>(out WeaponManager wm))
        {
            wm.AddWeapon(this);
        }
    }
}
