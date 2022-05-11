using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreSceneManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] ScoreSO so;
    [SerializeField] List<ScoreSO> levelsData;
    [SerializeField] List<TextMeshProUGUI> scoreTexts;


    private void Start()
    {
        levelsData = LevelProvider.Instace.LevelsData;

        for (int i = 0; i < levelsData.Count; i++)
        {
            scoreTexts[i].text = levelsData[i].maxScore.ToString();
        }
        //scoreText.text = so.maxScore.ToString();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
