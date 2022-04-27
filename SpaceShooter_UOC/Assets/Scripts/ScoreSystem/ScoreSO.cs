using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreData", menuName = "ScoreData")]
public class ScoreSO : ScriptableObject
{
    public int maxScore;
    PlayerPrefsSerializer serializer;
    private void OnEnable()
    {
        serializer = new PlayerPrefsSerializer();
        SetMaxScore(serializer.LoadMaxScore());
        Debug.Log("ScoreData Awake. MaxScore:" + maxScore);
    }
    public void SetMaxScore(int maxScore)
    {
        this.maxScore = maxScore;
    }

    [ContextMenu("Delete PlayerPrefs Data")]
    private void CleanPlayerPrefs()
    {
        PlayerPrefs.DeleteKey("maxScore");
    }
}
