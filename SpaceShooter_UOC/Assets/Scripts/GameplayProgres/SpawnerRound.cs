using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnerRound
{
    [SerializeField] SpawnerEnum spawnerType;
    public  Spawner spawner;
    [SerializeField] int cantidad;
    [SerializeField] float timeSpawn;

    public int Cantidad { get => cantidad; }

    public void InicializeSpawner()
    {
        spawner = GameManager.Instance.GetSpawner(spawnerType);
        if (spawner != null)
        {
            spawner.InicializeSpawner(timeSpawn);
        }
        else
            Debug.LogError("No se ha encontrado el spawner");
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
