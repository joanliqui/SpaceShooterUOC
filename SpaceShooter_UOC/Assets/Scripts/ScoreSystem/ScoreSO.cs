using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreData", menuName = "ScoreData")]
public class ScoreSO : ScriptableObject
{
    public int score;
    public int maxScore;
}
