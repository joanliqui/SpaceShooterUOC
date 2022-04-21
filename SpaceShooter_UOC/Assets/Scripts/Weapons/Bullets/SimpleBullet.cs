using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : BaseBullet
{
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

}
