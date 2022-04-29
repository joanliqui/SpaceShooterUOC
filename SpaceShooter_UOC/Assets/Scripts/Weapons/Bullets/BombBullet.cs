using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBullet : BaseBullet
{
    
    private float power = 10.0f;
    private float radius = 8.0f;

    private void OnEnable()
    {
        lifeTime = 0;
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        lifeTime += Time.deltaTime;
        if(lifeTime > maxLifeTime)
        {
            pool.ReturnToPool(this.gameObject);
        }
    }
    
    void BombDamage(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (var hitCollider in hitColliders) ;
        {
            //Rigidbody rb = hit.GetComponent<Rigidbody>();
            //if (rb != null)
            //{
              //  rb.AddExplosionForceCenter(power, center, radius);
            //}
        }
    }
}

