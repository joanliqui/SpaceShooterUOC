using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour, IDamagable, IPoolObject
{
    [SerializeField] protected int movSpeed = 10;
    [SerializeField] protected int health = 50;
    [SerializeField] protected WeaponPowerUp powerUp;
    protected AudioSource source;
    [SerializeField] protected int points = 10;
    [SerializeField] protected GameObject explosionPrefab;
    protected Pool explosionPool;
    [SerializeField] protected AudioSource explosion;
    private GameObject rend;
    private Collider col;

    [Header("Pool References")]
    private Pool commingFromPool;

    public Pool Pool 
    {
        get { return commingFromPool; }
        set 
        {
            if(commingFromPool == null)
            {
                commingFromPool = value;
            }
        }
    }

    private void Awake()
    {
        rend = transform.GetChild(0).gameObject;
        col = GetComponent<Collider>();
        if(explosionPool == null)
        {
            explosionPool = GameObject.FindGameObjectWithTag("ExplosionPool").GetComponent<Pool>();
        }
    }
    public virtual void Attack()
    {

    }

    public virtual void Destroyed()
    {
        GameObject o = Instantiate(powerUp.gameObject, transform.position, Quaternion.identity);

        GameObject exp = explosionPool.Get();
        exp.SetActive(true);
        exp.transform.position = transform.position;

        AddPoints();
        explosion.Play();
        rend.SetActive(false);
        col.enabled = false;
        StartCoroutine(DeacivateShip(explosion.clip.length));
    }

    IEnumerator DeacivateShip(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
        rend.SetActive(true);
        col.enabled = true;
    }
    public virtual void Damaged(int damage)
    {
       
    }

    public virtual void AddPoints()
    {
        ScoreManager.Instance.AddScorePoints(points);
    }
}
