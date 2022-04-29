using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndCondition : MonoBehaviour
{
    [Header("EndPanels")]
    [SerializeField] GameObject endPanel;
    [SerializeField] GameObject victoryPanel;
    [SerializeField] GameObject losePanel;
    [SerializeField] GameObject newRecordImage;
    [SerializeField] TextMeshProUGUI scoreText;

    [Header("TimeScaleVariables")]
    [SerializeField] bool reduceTimeScale = true;
    bool finish = false;
    float reduceTimeSpeed = 0.3f;
    float cntTimeScale = 1;
    public void InicializeEndCondition()
    {
        endPanel.SetActive(false);
        victoryPanel.SetActive(false);
        losePanel.SetActive(false);
        newRecordImage.SetActive(false);
        cntTimeScale = 1.0f;
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
        scoreText.text = ScoreManager.Instance.Score.ToString();
        if(ScoreManager.Instance.Score > ScoreManager.Instance.MaxScore)
        {
            newRecordImage.SetActive(true);
            ScoreManager.Instance.SaveMaxScore();
        }
    }

    public void GameLose()
    {
        finish = true;
    }
}
