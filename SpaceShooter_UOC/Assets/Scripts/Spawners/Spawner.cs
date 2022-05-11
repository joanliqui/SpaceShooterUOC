using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Pool enemyPool;
    float timeSpawn = 0.2f;
    bool inUse;
    bool finished;

    public delegate void SpawnHandler();
    public event SpawnHandler Spawned;

    public float TimeSpawn { get => timeSpawn; set => timeSpawn = value; }
    public bool Finished { get => finished; }

    private void Start()
    {
        enemyPool = GetComponent<Pool>();
    }

    public void InicializeSpawner(float time)
    {
        inUse = false;
        finished = false;
        timeSpawn = time;
    }
    
    [ContextMenu("SpawnEnemy")]
    public void SpawnEnemy(int cantidad, Round round)
    {
        inUse = true;
        finished = false;
        StartCoroutine(SpawnWaiting(cantidad, round));
    }

    IEnumerator SpawnWaiting(int cantidad, Round round)
    {
        for (int i = 0; i < cantidad; i++)
        {
            yield return new WaitForSeconds(timeSpawn);
            GameObject shot = enemyPool.Get();
            shot.SetActive(true);
            shot.transform.position = transform.position;
            shot.transform.rotation = transform.rotation;

            if(shot.TryGetComponent<IRoundObject>(out IRoundObject t))
            {
                t.Round = round;
            }

            Spawned?.Invoke();
        }
        finished = true;
        inUse = false;
    }
}
