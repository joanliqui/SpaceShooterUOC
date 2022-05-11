using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void PlayButton()
    {
        LevelProvider provider = GameObject.FindGameObjectWithTag("LevelProvider").GetComponent<LevelProvider>();
        if(provider != null)
            provider.SetLevelToProvide(1);

        SceneManager.LoadScene("GameplayScene");
    }

    public void ScoreMenuButton()
    {
        SceneManager.LoadScene("ScoreScene");
    }
}
