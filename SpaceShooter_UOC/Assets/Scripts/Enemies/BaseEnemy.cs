using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour, IDamagable, IPoolObject, IRoundObject
{
    [SerializeField] protected int movSpeed = 10;
    [SerializeField] protected int health = 50;
    [SerializeField] protected int points = 10;

    protected Pool explosionPool;
    [SerializeField] protected AudioSource explosionSource;
    protected GameObject rend;
    protected Collider col;
    protected PowerUpManager powerUpManager;

    [Header("Pool References")]
    protected Pool commingFromPool;
    protected bool isAlive = true;


    protected Round round;
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
    public Round Round 
    {
        get { return round; }
        set 
        {
            round = value;
        }
    }

    private void Awake()
    {
        if(rend == null)
        {
            rend = transform.GetChild(0).gameObject;
        }
        if(col == null)
        {
            col = GetComponent<Collider>();
        }
        if(explosionSource == null)
        {
            explosionSource = GetComponent<AudioSource>();
        }
        if(explosionPool == null)
        {
            explosionPool = GameObject.FindGameObjectWithTag("ExplosionPool").GetComponent<Pool>();
        }
        if(powerUpManager == null)
        {
            powerUpManager = GameObject.FindGameObjectWithTag("PowerUpManager").GetComponent<PowerUpManager>();
        }
    }
    protected virtual void OnEnable()
    {
        isAlive = true;
        if (rend == null)
        {
            rend = transform.GetChild(0).gameObject;
        }
        if (col == null)
        {
            col = GetComponent<Collider>();
        }
        if (explosionPool == null)
        {
            explosionPool = GameObject.FindGameObjectWithTag("ExplosionPool").GetComponent<Pool>();
        }
        if (explosionSource == null)
        {
            explosionSource = GetComponent<AudioSource>();
        }

    }
    public virtual void Attack()
    {

    }

    public virtual void Destroyed()
    {
        if(round != null)
        {
            round.TotalEnemiesInRound--;
            round = null;
        } 

        if(powerUpManager != null  )
        {
            if (powerUpManager.CanGenerateWeapon())
            {
                GameObject o = Instantiate(powerUpManager.GetWeaponPowerUp(), transform.position, Quaternion.identity);
            }
        }
        if(explosionPool != null)
        {
            GameObject exp = explosionPool.Get();
            exp.SetActive(true);
            exp.transform.position = transform.position;
        }

        AddPoints();
        if(explosionSource != null)
            explosionSource.Play();
        if(rend)
            rend.SetActive(false);
        if(col)
            col.enabled = false;

        isAlive = false;
        StartCoroutine(DeacivateEnemy(explosionSource.clip.length));
    }

    public void OutOfView()
    {
        if(round != null)
        {
            round.TotalEnemiesInRound--;
            round = null;
        }
        if(commingFromPool)
            commingFromPool.ReturnToPool(this.gameObject);
    }

    IEnumerator DeacivateEnemy(float time)
    {
        yield return new WaitForSeconds(time);
        commingFromPool.ReturnToPool(this.gameObject);
        rend.SetActive(true);
        col.enabled = true;
    }
    public virtual void Damaged(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroyed();
        }
    }

    public virtual void AddPoints()
    {
        ScoreManager.Instance.AddScorePoints(points);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IDamagable p = other.GetComponent<IDamagable>();
            if (p != null)
            {
                p.Damaged(1);
            }
            Destroyed();
        }
    }
}
