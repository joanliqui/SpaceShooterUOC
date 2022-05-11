using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsSerializer : BaseSerializer
{
    public override int LoadMaxScore()
    {
        return PlayerPrefs.GetInt("maxScore");
    }

    public override void SaveData(ScoreSO data)
    {
        PlayerPrefs.SetInt("maxScore", data.maxScore);
    }
}
