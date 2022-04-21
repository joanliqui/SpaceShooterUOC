using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour, IDamagable
{
    [SerializeField] protected int health = 50;
    [SerializeField] protected WeaponPowerUp powerUp;
    protected AudioSource source;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Attack()
    {

    }

    public virtual void Destroyed()
    {
        
    }

    public virtual void Damaged(int damage)
    {
       
    }
}
