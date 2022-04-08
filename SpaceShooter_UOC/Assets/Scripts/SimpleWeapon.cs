using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SimpleWeapon : Weapon
{
    public override void Shot(Transform socket)
    {
        Debug.Log("Shooting Simple Bullets");
        //Instantiate(bulletPrefab, socket.position, Quaternion.identity);
    }
}
