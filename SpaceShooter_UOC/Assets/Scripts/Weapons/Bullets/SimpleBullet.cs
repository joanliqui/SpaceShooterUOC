using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : BaseBullet
{
    GameObject mesh;   
    private void OnEnable()
    {
        lifeTime = 0;
        hit = false;
    }

    private void Start()
    {
        if(hitSource == null)
        {
            hitSource = GetComponent<AudioSource>();
        }
        mesh = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        lifeTime += Time.deltaTime;

        if(lifeTime > maxLifeTime)
        {
            if (!hit)
            {
               pool.ReturnToPool(this.gameObject);
            }
        }
    }

    protected override IEnumerator Deacivate()
    {
        col.enabled = false;
        mesh.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        col.enabled = true;
        mesh.SetActive(true);
        pool.ReturnToPool(this.gameObject);
    }

}
