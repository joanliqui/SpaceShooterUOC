using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMoveSpawner : MonoBehaviour
{
    [SerializeField] Spawner spawner;
    public virtual void Start()
    {
        spawner.Spawned += UpdateSpawnerPosition;
    }
    public abstract void UpdateSpawnerPosition();
}
