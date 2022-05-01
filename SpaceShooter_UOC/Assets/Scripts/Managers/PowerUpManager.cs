using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    WeaponManager wm;

    [SerializeField] GameObject[] powerUps;
    [SerializeField] int nothing, shotgunProb, bombProb, laserProb;
    int rand;


    void Start()
    {
        wm = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponManager>();
    }

    public bool CanGenerateWeapon()
    {
        rand = Random.Range(0, 101);
        if (rand >= 0 && rand <= nothing)
        {
            return false;
        }
        return true;
    }

    public GameObject GetWeaponPowerUp()
    {
        int n = 0;
        if(rand >= 0 && rand <= nothing)
        {
            return null;
        }
        else if(rand > nothing && rand <= nothing + shotgunProb)
        {
            n = 0;
        }
        else if(rand > nothing + shotgunProb  && rand <= nothing + shotgunProb + bombProb )
        {
            n = 1;
        }
        else if(rand > nothing + shotgunProb + bombProb && rand <= 100)
        {
            n = 2;
        }

        return powerUps[n];
    }
}
