using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSerializer
{
    public abstract void SaveData(Data data);

    public abstract Data LoadData(string path);
}
