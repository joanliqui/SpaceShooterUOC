using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] private int poolSize = 10;
    private int cntInPool = 0;

    Queue<GameObject> objects = new Queue<GameObject>();
    [SerializeField] bool preReload = false;

    private void Start()
    {
        if(preReload)
            AddObjects(poolSize);
    }
    public GameObject Get()
    {
        if (objects.Count == 0)
        {
            AddObjects(2);
        }

        return objects.Dequeue();
        
    }

    public void ReturnToPool(GameObject objectToReturn)
    {
        objectToReturn.SetActive(false);
        objects.Enqueue(objectToReturn);
    }
    private void AddObjects(int n)
    {
        for (int i = 0; i < n; i++)
        {
            GameObject newObject = Instantiate(prefab);
            objects.Enqueue(newObject);
            newObject.GetComponent<IPoolObject>().Pool = this;
            newObject.SetActive(false);

        }
        cntInPool = objects.Count;
    }
}
