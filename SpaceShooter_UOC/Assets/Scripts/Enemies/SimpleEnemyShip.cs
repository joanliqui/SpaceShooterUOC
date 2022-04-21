using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyShip : BaseEnemy, IDamagable
{
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        
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
        gameObject.SetActive(false);
    }
}
