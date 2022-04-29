using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminateObjectsCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<IPoolObject>(out IPoolObject p))
        {
            if(other.TryGetComponent<BaseEnemy>(out BaseEnemy enemy))
            {
                enemy.OutOfView();
                return;
            }

            p.Pool.ReturnToPool(other.gameObject);
        }
    }
}
