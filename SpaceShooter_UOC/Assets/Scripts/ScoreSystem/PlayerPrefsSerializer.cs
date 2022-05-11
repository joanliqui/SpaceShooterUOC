using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsSerializer : BaseSerializer
{
    public override Data LoadData(string fileName) //YA NO SE USA, AHORA MISMO NO FUNCIONA
    {
        PlayerPrefs.GetInt("maxScore");
        return null;
    }

    public override void SaveData(Data data)
    {
        PlayerPrefs.SetInt("maxScore", data.maxScore);
    }
}
