using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSerializer
{
    public abstract void SaveData(ScoreSO data);

    public virtual int LoadMaxScore()
    {
        return 0;
    }
}
