using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWeapon : Weapon
{
    [Header("Concretes")]
    [Space(10)]
    [SerializeField] float timeLaserActive = 0.5f;
    private float cntTime = 0;
    [SerializeField] int laserDamage = 5;
    [SerializeField] float timeBtwDamage = 0.1f;
    [SerializeField] private LineRenderer[] lines;
    private bool isShooting = false;
    private bool canDamage = true;
    private Transform socket;
    private Transform[] sockets;
    RaycastHit hit;

    void Start()
    {
        foreach (LineRenderer item in lines)
        {
            item.enabled = false;
            item.useWorldSpace = true;
        }
    }

    public override void Shot(Transform socket, AudioSource source)
    {
        cntTime = 0.0f;
        this.socket = socket;
        isShooting = true;
    }

    public override void Shot(Transform[] sockets, AudioSource source)
    {
        cntTime = 0.0f;
        this.sockets = sockets;
        isShooting = true;
    }


    IEnumerator KeepLaserActivate(Transform[] sockets, int n) //Esta maneja UN rayo
    {
        if (Physics.Raycast(sockets[n].position, sockets[n].forward, out hit))
        {

        }
        yield return new WaitForSeconds(timeLaserActive);
    }

 

    public void Update()
    {
        if (isShooting)
        {

            if(cntTime < timeLaserActive)
            {
                cntTime += Time.deltaTime;
                if (fromOneSocket)
                {
                    OneLaser();
                }
                else
                {
                    TwoLasers();
                }

            }
            else
            {
                foreach (LineRenderer item in lines)
                {
                    item.enabled = false;
                }
                isShooting = false;
            }
            
        }
    }

    private void OneLaser()
    {
        if (lines[0].enabled == false)
        {
            lines[0].enabled = true;
        }
        lines[0].SetPosition(0, socket.position);

        if (Physics.Raycast(socket.position, socket.forward, out hit))
        {
            lines[0].SetPosition(1, hit.point);
            if (hit.transform.TryGetComponent<IDamagable>(out IDamagable enemy))
            {
                enemy.Damaged(laserDamage);
            }
        }
        else
        {
            lines[0].SetPosition(1, socket.forward * 100);
        }
    }

    private void TwoLasers()
    {
        for (int i = 0; i < sockets.Length; i++)
        {
            lines[i].enabled = true;
            lines[i].SetPosition(0, sockets[i].position);
            if(Physics.Raycast(sockets[i].position, sockets[i].forward, out hit))
            {
                lines[i].SetPosition(1, hit.point);
                if (canDamage)
                {
                    if (hit.transform.TryGetComponent<IDamagable>(out IDamagable enemy))
                    {
                        enemy.Damaged(laserDamage);
                        Debug.Log("Hit");
                        StartCoroutine(ApplyDamage());
                    }
                }
            }
            else
            {
                lines[i].SetPosition(1, socket.forward * 100);
            }
        }
    }

    IEnumerator ApplyDamage()
    {
        canDamage = false;
        yield return new WaitForSeconds(timeBtwDamage);
        canDamage = true;
    }
}
