using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    private int maxScore = 0;
    private int score;
    [SerializeField] ScoreSO scoreSO;

    private int visualScore;
    [SerializeField] TextMeshProUGUI scoreText;
    private static ScoreManager _instance;

    #region Propiedades
    public static ScoreManager Instance { get => _instance;}
    public int Score { get => score; set => score = value; }
    public int MaxScore { get => maxScore; set => maxScore = value; }
    #endregion

    void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else if(_instance != this)
        {
            Destroy(gameObject);
        }

        maxScore = scoreSO.maxScore;
        score = 0;
        visualScore = 0;
        scoreText.text = "0";
    }

    private void Start()
    {
        
    }

    public void AddScorePoints(int points)
    {
        score += points;
        StartCoroutine(AddPointsWithTime(points));
    }


    IEnumerator AddPointsWithTime(int points)
    {
        for (int i = 0; i < points; i++)
        {
            visualScore++;
            scoreText.text = visualScore.ToString();
            yield return new WaitForSeconds(0.007f);
        }
    }

    public void SaveMaxScore()
    {
        maxScore = score;
        scoreSO.SetMaxScore(maxScore);
    }
}
