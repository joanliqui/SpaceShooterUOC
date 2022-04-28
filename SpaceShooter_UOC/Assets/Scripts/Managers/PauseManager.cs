using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    private static PauseManager _instance;
    [SerializeField] GameObject pauseMenu;
    private bool isPaused = false;
    [SerializeField] Button pauseButton;
    [SerializeField] TextMeshProUGUI maxScoreText;
    [SerializeField] GameObject normalPauseUI;
    [SerializeField] GameObject questionUI;
    InputManager inputs;

    public static PauseManager Instance { get => _instance; }

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
        inputs = GameObject.FindGameObjectWithTag("Player").GetComponent<InputManager>();
        isPaused = false;
        if(maxScoreText)
            maxScoreText.text = ScoreManager.Instance.MaxScore.ToString();
        if(questionUI)
            questionUI.SetActive(false);
        if(pauseMenu)
            pauseMenu.SetActive(false);
    }

    public void Pause()
    {
        inputs.DisconnectInput();
        isPaused = true;
        Time.timeScale = 0.0f;
        pauseButton.interactable = false;

        pauseMenu.SetActive(true);
        normalPauseUI.SetActive(true);
    }

    public void Resume()
    {
        inputs.ConnectInput();
        isPaused = false;
        pauseButton.interactable = true;
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
    }

    public void MainMenuButton()
    {
        normalPauseUI.SetActive(false);
        questionUI.SetActive(true);
    }

    public void GoMainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenuScene");
    }

    public void BackToNormalPause()
    {
        questionUI.SetActive(false);
        normalPauseUI.SetActive(true);
    }
}
