using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunWeapon : Weapon
{
    [Space(10)]
    [Tooltip("El numero de balas que disparara en un disparo")]
    [SerializeField] int numberBullets = 3;
    public override void Shot(Transform socket, AudioSource source)
    {
        for (int i = 0; i < numberBullets; i++)
        {
            if (bulletPool != null)
            {
                GameObject shot = bulletPool.Get();
                shot.SetActive(true);
                shot.transform.position = socket.position;
                shot.transform.rotation = socket.rotation;
            }
        }

        if (source != null)
        {
            if (source.clip != clip)
            {
                source.clip = clip;
            }

            source.Play();
        }
    }

    public override void Shot(Transform[] socket, AudioSource source)
    {
        for (int i = 0; i < socket.Length; i++)
        {
            for (int j = 0; j < numberBullets; j++)
            {
                if (bulletPool != null)
                {
                    GameObject shot = bulletPool.Get();
                    shot.SetActive(true);
                    shot.transform.position = socket[i].position;
                    shot.transform.rotation = socket[i].rotation;
                }
            }
        }
        if (source != null)
        {
            if (source.clip != clip)
            {
                source.clip = clip;
            }

            source.Play();
        }
    }
}
