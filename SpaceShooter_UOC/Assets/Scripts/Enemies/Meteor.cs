using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : BaseEnemy, IPoolObject, IDamagable
{
    [Header("Meteorito")]
    [Space(10)]
    [SerializeField] float minSpeed;
    [SerializeField] float maxSpeed;
    Rigidbody rb;
    Transform target;
    Vector3 movDir;
    private float speed;

    public override void Damaged(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroyed();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        movDir = (target.transform.position - transform.position).normalized;
        speed = Random.Range(minSpeed, maxSpeed);

        rb.velocity = movDir * speed;
    }

    private void OnEnable()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
