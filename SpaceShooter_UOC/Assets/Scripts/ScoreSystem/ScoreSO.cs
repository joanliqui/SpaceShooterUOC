using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreData", menuName = "ScoreData")]
public class ScoreSO : ScriptableObject
{
    public string level;
    public int maxScore;


    BaseSerializer serializer;
    private void OnEnable()
    {
        serializer = new XMLSerializer();
        maxScore = serializer.LoadMaxScore();
        Debug.Log("ScoreData Awake. MaxScore:" + maxScore);
    }
    public void SetMaxScore(int maxScore)
    {
        this.maxScore = maxScore;
        SaveData();
    }

    private void SaveData()
    {
        serializer.SaveData(this);
    }



    [ContextMenu("Delete PlayerPrefs Data")]
    private void CleanPlayerPrefs()
    {
        PlayerPrefs.DeleteKey("maxScore");
    }
}
