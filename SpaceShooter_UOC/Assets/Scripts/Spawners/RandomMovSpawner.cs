using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovSpawner : BaseMoveSpawner
{
    Camera cam;
    Vector3 initialPos;
    [SerializeField] float space = 20f;
    float lastPos;
    float newPos;
    public override void Start()
    {
        base.Start();
        cam = Camera.main;
        initialPos = transform.position;
        lastPos = 0;
        newPos = 0;
    }
    public override void UpdateSpawnerPosition()
    {
        do
        {
            newPos = Random.Range(-40f, 5f);

        } while (newPos > lastPos - space && newPos < lastPos + space);

        lastPos = newPos;
        transform.position = new Vector3(newPos, initialPos.y, initialPos.z);
    }

}
