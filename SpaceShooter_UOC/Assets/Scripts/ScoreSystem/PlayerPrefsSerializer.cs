using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsSerializer : BaseSerializer
{
    public override void SaveMaxScore()
    {
        PlayerPrefs.SetInt("maxScore", 0);
    }
    public override int LoadMaxScore()
    {
        return PlayerPrefs.GetInt("maxScore");
    }
}
