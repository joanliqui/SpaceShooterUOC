using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    private static PauseManager _instance;
    [SerializeField] GameObject pauseMenu;
    private bool isPaused = false;
    [SerializeField] Button pauseButton;
    [SerializeField] TextMeshProUGUI maxScoreText;
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

    private void OnEnable()
    {
        maxScoreText.text = ScoreManager.Instance.MaxScore.ToString();
    }
    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0.0f;
        pauseButton.interactable = false;
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        isPaused = false;
        pauseButton.interactable = true;
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
    }
}
