using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBullet : BaseBullet
{
    [Header("Bomb Parameters")]
    [Space(10)]
    [SerializeField] float radius = 3f;
    private bool oneExplosion;
    [SerializeField] LayerMask enemyLayer;

    private void OnEnable()
    {
        hit = false;
        lifeTime = 0;
        oneExplosion = true;
    }
    //Para este escipt el lifeTime en verdad es movingTime, es decir, el timpo que tarda en quedarse quieta
    void Update()
    {
        if (!hit)
        {
            if(lifeTime < maxLifeTime)
            {
                transform.position += transform.forward * speed * Time.deltaTime;
                lifeTime += Time.deltaTime;
            }
            else
            {
                if (oneExplosion)
                {
                    Debug.Log("Explota por tiempo");
                    oneExplosion = false;
                    ExplosionArea();
                    StartCoroutine(Deacivate());
                }
            }
        }

    }

    private void ExplosionArea()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, radius, enemyLayer);
        foreach (Collider item in cols)
        {
            if(item.TryGetComponent<IDamagable>(out IDamagable damagable))
            {
                damagable.Damaged(damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
        if (!oneExplosion || hit)
        {
            Gizmos.color = Color.red;
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        //Explota dañando en area
        ExplosionArea();
        Debug.Log("Explota por Hit");
        //Hace el daño del impacto, suena el sonido, sale la particula de impacot y se desactiva y vuelve a la pool
        base.OnTriggerEnter(other);
    }

}

