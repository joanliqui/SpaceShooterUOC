using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour, IPoolObject
{
    [SerializeField] private float timeToPool = 1.5f;
    ParticleSystem ps;
    private Pool pool;
    public Pool Pool 
    { 
        get { return pool; }
        set
        {
            if(pool == null)
            {
                pool = value;
            }
        } 
    }
    
    
    IEnumerator ToPool()
    {
        yield return new WaitForSeconds(timeToPool);
        if(pool)
            pool.ReturnToPool(this.gameObject);
        else
        {
            gameObject.SetActive(false);
        }
    }
    private void OnEnable()
    {
        ps.Play();
        ToPool();
    }

    public void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }

}
