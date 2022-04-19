using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyShip : BaseEnemy, IDamagable
{
    public override void Damaged(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroyed();
        }
    }

    public override void Destroyed()
    {
        GameObject o = Instantiate(powerUp, transform.position, Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
