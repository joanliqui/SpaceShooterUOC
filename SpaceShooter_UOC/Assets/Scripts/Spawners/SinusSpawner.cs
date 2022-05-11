using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinusSpawner : BaseMoveSpawner
{
    [SerializeField] int nMoves = 3;
    [SerializeField] float spaceToMove = 5;
    int cntDirMoves = 0;
    private int dir = 1;
    Vector3 initialPose;
    public override void UpdateSpawnerPosition()
    {
        cntDirMoves++;
        if(cntDirMoves == nMoves)
        {
            dir *= -1;
            cntDirMoves = 0;
            transform.position = initialPose;
        }
        transform.position += transform.right * dir * spaceToMove;
    }

    public override void Start()
    {
        initialPose = transform.position;
        base.Start();
    }
}
