using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour, IDamagable
{
    [SerializeField] protected int movSpeed = 10;
    [SerializeField] protected int health = 50;
    [SerializeField] protected WeaponPowerUp powerUp;
    protected AudioSource source;
    [SerializeField] protected int points = 10;
    [SerializeField] protected GameObject explosionPrefab;
    [SerializeField] protected Pool explosionPool;

    public virtual void Attack()
    {

    }

    public virtual void Destroyed()
    {
        
    }

    public virtual void Damaged(int damage)
    {
       
    }

    public virtual void AddPoints()
    {
        ScoreManager.Instance.AddScorePoints(points);
    }
}
