using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBullet : MonoBehaviour, IPoolObject
{
    [SerializeField] protected float speed;
    [SerializeField] protected int damage;
    protected Camera cam;
    [SerializeField] protected float maxLifeTime = 2f;
    protected float lifeTime;
    [Header("For Disconnect")]
    protected Collider col;
    protected GameObject mesh;
    protected Pool pool;
    protected Pool impactParticlePool; 

    protected AudioSource hitSource;
    protected bool hit = false; 

    private void Awake()
    {
        cam = Camera.main;
        col = GetComponent<Collider>();
        mesh = transform.GetChild(0).gameObject;

        impactParticlePool = GameObject.FindGameObjectWithTag("BulletParticlePool").GetComponent<Pool>();
        if(hitSource == null)
        {
            hitSource = GetComponent<AudioSource>();
        }
    }


    private void OnEnable()
    {
        hit = false;
        lifeTime = 0;
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

            //Instanciar Particula de impacto
            GameObject g = impactParticlePool.Get();
            g.SetActive(true);
            g.transform.position = transform.position;

            //Sonido de golpe
            if(hitSource)
                hitSource.Play();

            //Desactivar componentes y volver a la pool
            StartCoroutine(Deacivate());
        }
    }

    protected virtual IEnumerator Deacivate()
    {
        col.enabled = false;
        mesh.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        col.enabled = true;
        mesh.SetActive(true);
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
