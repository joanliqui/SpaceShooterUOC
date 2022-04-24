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
    protected Pool impactParticlePool; 
    protected Collider col;
    protected AudioSource hitSource;
    protected bool hit = false; 

    private void Awake()
    {
        cam = Camera.main;
        col = GetComponent<Collider>();
        impactParticlePool = GameObject.FindGameObjectWithTag("BulletParticlePool").GetComponent<Pool>();
        if(hitSource == null)
        {
            hitSource = GetComponent<AudioSource>();
        }
    }


    private void OnEnable()
    {
        hit = false;
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
            hit = true;
            damaged.Damaged(damage);
            GameObject g = impactParticlePool.Get();
            g.SetActive(true);
            g.transform.position = transform.position;
            hitSource.Play();
            StartCoroutine(Deacivate());
        }
    }

    protected virtual IEnumerator Deacivate()
    {
        col.enabled = false;
        yield return new WaitForSeconds(1.5f);
        pool.ReturnToPool(this.gameObject);
    }

    protected bool IsInView()
    {
        return RendererExtensions.IsVisibleFrom(col, cam);
    }

    protected virtual void DestroyBullet()
    {

    }

}
