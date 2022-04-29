using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Round
{
    [SerializeField] List<SpawnerRound> enemysRound;
    [SerializeField] bool inRound;
    [SerializeField] int totalEnemiesInRound;

    public bool InRound { get => inRound; set => inRound = value; }
    public int TotalEnemiesInRound { get => totalEnemiesInRound; set => totalEnemiesInRound = value; }

    public void InicialiceRound()
    {
        int t = 0;
        foreach (SpawnerRound item in enemysRound)
        {
            item.InicializeSpawner();
            t += item.Cantidad;
        }
        totalEnemiesInRound = t;
    }

    public void Play()
    {
        inRound = true;
        foreach (SpawnerRound item in enemysRound)
        {
            item.SpawnEnemies(this);
        }
    }

    public bool IsRoundFinished()
    {

        return totalEnemiesInRound <= 0;

    }
}
