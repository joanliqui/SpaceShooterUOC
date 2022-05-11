using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreData", menuName = "ScoreData")]
public class ScoreSO : ScriptableObject
{
    private Data data;

    public string level;
    public int maxScore;


    BaseSerializer serializer;
    private void OnEnable()
    {
        serializer = new XMLSerializer();
        LoadData();
    }
    public void SetMaxScore(int maxScore)
    {

        this.maxScore = maxScore;
        data.maxScore = maxScore;
        serializer.SaveData(this.data);
    }


    void LoadData() //Esto solo se usa al encender la aplicación
    {
        data = serializer.LoadData(level);
        if(data != null)
        {
            maxScore = data.maxScore;
        }
        else
        {
            data = new Data(level);
        }
        Debug.Log("ScoreData Awake. MaxScore:" + maxScore);
    }


    [ContextMenu("Delete PlayerPrefs Data")]
    private void CleanPlayerPrefs()
    {
        PlayerPrefs.DeleteKey("maxScore");
    }
}
