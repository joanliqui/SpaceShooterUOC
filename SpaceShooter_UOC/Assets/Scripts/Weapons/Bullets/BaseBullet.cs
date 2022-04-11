using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBullet : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected int damage;

    public virtual void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<IDamagable>(out IDamagable damaged))
        {
            damaged.Damaged(damage);
            Destroy(gameObject);
        }
    }
}
