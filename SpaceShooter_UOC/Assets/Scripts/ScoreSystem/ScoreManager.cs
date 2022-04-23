using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    private int maxScore = 0;
    private int score;
    [SerializeField] ScoreSO scoreSO; 

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
    }

    private void Start()
    {
        maxScore = scoreSO.maxScore;
        score = 0;
        scoreText.text = "0";
    }

    public void AddScorePoints(int points)
    {
        StartCoroutine(AddPointsWithTime(points));
    }


    IEnumerator AddPointsWithTime(int points)
    {
        for (int i = 0; i < points; i++)
        {
            score++;
            scoreText.text = score.ToString();
            yield return new WaitForSeconds(0.007f);
        }
    }
}
