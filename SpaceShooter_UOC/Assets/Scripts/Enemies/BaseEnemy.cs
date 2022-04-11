using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    [SerializeField] protected int health = 50;

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
        Destroy(gameObject);
    }
}
