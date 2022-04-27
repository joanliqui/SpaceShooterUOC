using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Round
{
    [SerializeField] List<SpawnerRound> enemysRound;
    [SerializeField] bool inRound;
    [SerializeField] int totalEnemies;

    public bool InRound { get => inRound; set => inRound = value; }

    public void InicialiceRound()
    {
        int t = 0;
        foreach (SpawnerRound item in enemysRound)
        {
            item.InicializeSpawner();
            t += item.Cantidad;
        }
        totalEnemies = t;
    }

    public void Play()
    {
        inRound = true;
        foreach (SpawnerRound item in enemysRound)
        {
            item.SpawnEnemies();
        }
    }

    public bool IsRoundFinished()
    {
        int n = 0;
        foreach (SpawnerRound item in enemysRound)
        {
            if (item.FinishSpawning())
            {
                n++;
            }
        }

        return n == enemysRound.Count;

    }
}
