using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyShip : BaseEnemy, IDamagable
{
    [Space(10)]
    [SerializeField] Transform socket;
    [SerializeField] float timeBtwShots;
    [SerializeField] Weapon weapon;
    private bool canShot = false; 
    void Awake()
    {
        canShot = true;
        StartCoroutine(Shooting());
        timeBtwShots = weapon.TimeBtwShots;
        if(weapon.BulletPool == null)
        {
            weapon.BulletPool = GameObject.FindGameObjectWithTag("EnemyPool").GetComponent<Pool>();
        }
    }

    protected override void OnEnable()
    {
        canShot = true;
        base.OnEnable();
    }
    void Update()
    {
        if (isAlive)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * movSpeed);
            if (canShot)
            {
                StartCoroutine(Shooting());
            }
        }
    }
    
    IEnumerator Shooting()
    {
        Attack();
        canShot = false;
        yield return new WaitForSeconds(timeBtwShots);
        canShot = true;
    }

    public override void Attack()
    {
        Debug.Log("Shot");
        weapon.Shot(socket, null);
    }
    public override void Damaged(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroyed();
        }
    }

}
