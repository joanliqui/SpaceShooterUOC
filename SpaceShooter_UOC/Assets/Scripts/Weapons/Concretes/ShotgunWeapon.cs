using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunWeapon : Weapon
{
    [Space(10)]
    [Tooltip("El numero de balas que disparara en un disparo")]
    [SerializeField] int numberBullets = 3;
    [Range(0, 45)]
    [SerializeField] int spreadAngle = 10;
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
        float addedAngle = spreadAngle;
        for (int i = 0; i < socket.Length; i++)
        {
            Quaternion rotation = socket[i].rotation * Quaternion.Inverse(Quaternion.Euler(0.0f, addedAngle * (numberBullets -1), 0.0f));
            for (int j = 0; j < numberBullets; j++)
            {
                if (bulletPool != null)
                {
                    GameObject shot = bulletPool.Get();
                    shot.SetActive(true);
                    shot.transform.position = socket[i].position;
                    shot.transform.rotation = rotation;
                    rotation *= Quaternion.Euler(0.0f, addedAngle, 0.0f);
                }
            }
            addedAngle *= -1;
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
