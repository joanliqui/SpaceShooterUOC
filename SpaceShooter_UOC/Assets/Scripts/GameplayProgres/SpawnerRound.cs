using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnerRound
{
    [SerializeField] private Spawner spawner;
    [SerializeField] int cantidad;
    [SerializeField] float timeSpawn;

    public int Cantidad { get => cantidad; }

    public void InicializeSpawner()
    {
        spawner.InicializeSpawner(timeSpawn);
    }
    public void SpawnEnemies(Round round)
    {
        spawner.SpawnEnemy(cantidad, round);
    }

    public bool FinishSpawning()
    {
        return spawner.Finished;
    }
}
