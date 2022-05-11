using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    private int maxScore = 0;
    private int score;
    [SerializeField] ScoreSO actualScoreSO;

    private int visualScore;
    [SerializeField] TextMeshProUGUI scoreText;
    private static ScoreManager _instance;

    const int playerLifeValor = 5000;
    PlayerLife playerLife;

    #region Propiedades
    public static ScoreManager Instance { get => _instance;}
    public int Score { get => score; set => score = value; }
    public int MaxScore { get => maxScore; set => maxScore = value; }
    public int PlayerLifeValor { get => playerLifeValor;}
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

        maxScore = actualScoreSO.maxScore;
        score = 0;
        visualScore = 0;
        scoreText.text = "0";
    }

    private void Start()
    {
        playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();
    }

    public void AddScorePoints(int points)
    {
        score += points;
        StartCoroutine(AddPointsWithTime(points, 0.007f));
    }


    IEnumerator AddPointsWithTime(int points, float time)
    {
        for (int i = 0; i < points; i++)
        {
            visualScore++;
            scoreText.text = visualScore.ToString();
            yield return new WaitForSeconds(time);
        }
    }

    public void SaveMaxScore()
    {
        maxScore = score;
        actualScoreSO.SetMaxScore(maxScore);
    }

    public int CalculateEndScore()
    {
        int valueLifePoints = 0;
        valueLifePoints = playerLifeValor * playerLife.CntLife;
        score += playerLifeValor * playerLife.CntLife;
        //scoreText.text = score.ToString();
        return valueLifePoints;
    }

}
