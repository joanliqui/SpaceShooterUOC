using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleShip : BaseEnemy, IDamagable
{
    public void Damaged(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroyed();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
