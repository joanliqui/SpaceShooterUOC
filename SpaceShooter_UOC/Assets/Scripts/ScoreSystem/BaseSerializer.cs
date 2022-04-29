using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSerializer
{
    public virtual void SaveMaxScore(int value)
    {

    }

    public virtual int LoadMaxScore()
    {
        return 0;
    }
}
