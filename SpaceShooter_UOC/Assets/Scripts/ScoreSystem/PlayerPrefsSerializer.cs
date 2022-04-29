using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsSerializer : BaseSerializer
{
    public override void SaveMaxScore(int value)
    {
        PlayerPrefs.SetInt("maxScore", value);
    }
    public override int LoadMaxScore()
    {
        return PlayerPrefs.GetInt("maxScore");
    }
}
