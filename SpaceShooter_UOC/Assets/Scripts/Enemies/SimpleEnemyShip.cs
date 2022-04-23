using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyShip : BaseEnemy, IDamagable
{
    [Space(10)]
    [SerializeField] Transform socket;
    [SerializeField] BaseBullet bullet;
    [SerializeField] float timeBtwShots;
    [SerializeField] Weapon weapon;
    private bool canShot = false; 
    void Start()
    {
        source = GetComponent<AudioSource>();
        StartCoroutine(Shooting());
        timeBtwShots = weapon.TimeBtwShots;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * movSpeed);
        if (canShot)
        {
            StartCoroutine(Shooting());
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

    public override void Destroyed()
    {
        GameObject o = Instantiate(powerUp.gameObject, transform.position, Quaternion.identity);
        AddPoints();
        gameObject.SetActive(false);
    }
}
