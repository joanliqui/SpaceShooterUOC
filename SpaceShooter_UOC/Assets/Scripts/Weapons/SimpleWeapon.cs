using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SimpleWeapon : Weapon
{
    [SerializeField] private AudioClip clip;
    public override void Shot(Transform[] socket, AudioSource source)
    {
        for (int i = 0; i < socket.Length; i++)
        {
            Instantiate(bulletPrefab, socket[i].position, Quaternion.identity);
        }
        if(source != null)
        {
            if(source.clip != clip)
            {
                source.clip = clip;
            }

            source.Play();
        }
        
    }
}
