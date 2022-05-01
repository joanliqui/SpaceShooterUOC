using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinusEnemy : BaseEnemy
{
    [Header("SinusoidalEnemy")]
    [Space(10)]
    [SerializeField] float frecuency = 10f;
    [SerializeField] float magnitude;
    private float timer;

    Vector3 pos;

    private void Start()
    {
        pos = transform.position;
        timer = 0;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        pos += transform.forward * Time.deltaTime * movSpeed;
        transform.position = pos + transform.right * Mathf.Sin(timer * frecuency) * magnitude; //Time.time hace que todos se muevan a la vez y no mola
    }

    public override void Damaged(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroyed();
        }
    }
}
