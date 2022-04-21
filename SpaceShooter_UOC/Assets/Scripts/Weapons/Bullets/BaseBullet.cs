using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBullet : MonoBehaviour, IPoolObject
{
    [SerializeField] protected float speed;
    [SerializeField] protected int damage;
    protected Camera cam;
    protected Pool pool;
    [SerializeField] protected float maxLifeTime = 2f;
    protected float lifeTime;

    private Collider col;

    private void Awake()
    {
        cam = Camera.main;
        col = GetComponent<Collider>();
    }

    public Pool Pool
    {
        get { return pool; }
        set
        {
            if (pool == null)
            {
                pool = value;
            }
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<IDamagable>(out IDamagable damaged))
        {
            damaged.Damaged(damage);
            pool.ReturnToPool(this.gameObject);

        }
    }

    protected bool IsInView()
    {
        return RendererExtensions.IsVisibleFrom(col, cam);
    }

    protected virtual void DestroyBullet()
    {

    }

}
