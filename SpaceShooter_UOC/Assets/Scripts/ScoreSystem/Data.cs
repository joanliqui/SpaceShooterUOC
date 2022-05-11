using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data 
{
    public string level;
    public int maxScore;

    public Data()
    {

    }
    public Data(string levelName)
    {
        this.level = levelName;
    }

  
}
