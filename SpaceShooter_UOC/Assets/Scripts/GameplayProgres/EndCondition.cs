using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCondition : MonoBehaviour
{
    [SerializeField] GameObject endPanel;
    [SerializeField] GameObject victoryPanel;
    [SerializeField] GameObject losePanel;

    public void InicializeEndCondition()
    {
        endPanel.SetActive(false);
        victoryPanel.SetActive(false);
        losePanel.SetActive(false);
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


    public void GameWin()
    {
        endPanel.SetActive(true);
        victoryPanel.SetActive(true);
    }

    public void GameLose()
    {

    }
}
