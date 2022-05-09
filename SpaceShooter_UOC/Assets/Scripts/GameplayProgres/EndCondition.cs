using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndCondition : MonoBehaviour
{
    [Header("EndPanels")]
    [Header("WinPanel")]
    [SerializeField] GameObject victoryPanel;
    [SerializeField] GameObject newRecordImage;
    [SerializeField] TextMeshProUGUI scoreTextWin;
    [SerializeField] TextMeshProUGUI nLifesText;
    [SerializeField] TextMeshProUGUI lifesPointsText;

    [Header("LosePanel")]
    [SerializeField] GameObject endPanel;
    [SerializeField] GameObject losePanel;
    [SerializeField] TextMeshProUGUI scoreTextLose;
    

    [Header("TimeScaleVariables")]
    [SerializeField] bool reduceTimeScale = true;
    bool finish = false;
    float reduceTimeSpeed = 0.3f;
    float cntTimeScale = 1;

    //[Header("Player")]
    private PlayerLife playerLife;
    public void InicializeEndCondition()
    {
        endPanel.SetActive(false);
        victoryPanel.SetActive(false);
        losePanel.SetActive(false);
        newRecordImage.SetActive(false);
        cntTimeScale = 1.0f;
        playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();
    }

    public void DestroyAllEnemies()
    {
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject item in enemies)
        {
            Destroy(item);
        }
    }

    private void Update()
    {
        if (reduceTimeScale)
        {
            if (finish)
            {
                if(cntTimeScale > 0.0f)
                {
                    cntTimeScale -= reduceTimeSpeed * Time.deltaTime;
                    Time.timeScale = cntTimeScale;
                }

            }
        }
    }

    public void CleanScene()
    {
        GameObject[] pw = GameObject.FindGameObjectsWithTag("PowerUp");
        foreach (GameObject item in pw)
        {
            Destroy(item);
        }

        GameObject[] enemyBullets = GameObject.FindGameObjectsWithTag("EnemyBullet");
        foreach (GameObject item in enemyBullets)
        {
            Destroy(item);
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject item in enemies)
        {
            Destroy(item);
        }
    }

    public void PanelGameWin()
    {
        finish = true;
        endPanel.SetActive(true);
        losePanel.SetActive(false);
        victoryPanel.SetActive(true);

        SetWinPanel();
    }

    private void SetWinPanel()
    {
        //Lifes
        nLifesText.text = playerLife.CntLife.ToString();
        lifesPointsText.text = "+" + ScoreManager.Instance.CalculateEndScore().ToString();
        //Score
        scoreTextWin.text = ScoreManager.Instance.Score.ToString();
        //MaxScore
        if(ScoreManager.Instance.Score > ScoreManager.Instance.MaxScore)
        {
            newRecordImage.SetActive(true);
            ScoreManager.Instance.SaveMaxScore();
        }
    }

    public void PanelGameLose()
    {
        finish = true;
        endPanel.SetActive(true);
        losePanel.SetActive(true);
        victoryPanel.SetActive(false);
        ScoreManager.Instance.SaveMaxScore();

        SetLosePanel();
    }

    private void SetLosePanel()
    {
        scoreTextLose.text = ScoreManager.Instance.Score.ToString();
    }
}
