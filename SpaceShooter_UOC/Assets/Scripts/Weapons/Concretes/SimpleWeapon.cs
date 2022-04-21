using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SimpleWeapon : Weapon
{
    //Solo dispara una bala
    public override void Shot(Transform socket, AudioSource source)
    {
        if(bulletPool != null)
        {
            GameObject shot = bulletPool.Get();
            shot.SetActive(true);  
            shot.transform.position = socket.position;
            shot.transform.rotation = socket.rotation;
        }

        if (source != null)
        {
            if(source.clip != clip)
            {
                source.clip = clip;
            }

            source.Play();
        }
    }

    //Dispara X balas
    public override void Shot(Transform[] socket, AudioSource source)
    {
        if(bulletPool != null)
        {
            for (int i = 0; i < socket.Length; i++)
            {
                GameObject shot = bulletPool.Get();
                shot.SetActive(true);
                shot.transform.position = socket[i].position;
                shot.transform.rotation = socket[i].rotation;
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
