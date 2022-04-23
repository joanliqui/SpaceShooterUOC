using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour, IDamagable
{
    private int life;

    public void Damaged(int damage)
    {
        if(life > 0)
        {
            life--;
            Debug.Log(life);
        }
        else 
        {
            Destroyed();
        }
    }

    public void Destroyed()
    {
        Debug.Log("HE MUERTO");
    }

    void Start()
    {
        life = 10;
    }

}
