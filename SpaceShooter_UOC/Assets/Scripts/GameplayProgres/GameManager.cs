using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get => _instance; }

    [Header("Player")]
    [SerializeField] GameObject playerShip;
    private Transform startPoint;
    private InputManager input;

    [Header("Rounds")]
    [SerializeField] List<Round> rounds;
    int nActualRound;
    Round actualRound;
    int frameRound;
    [SerializeField] UnityEvent OnGameBegins;
    [SerializeField] UnityEvent OnRoundFinished;
    [SerializeField] public UnityEvent OnGameWin;
    [SerializeField] public UnityEvent OnGameLose;
    private bool noMoreRounds = false;


    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        //InicializePlayer();
    }
    void Start()
    {
        input = GameObject.FindGameObjectWithTag("Player").GetComponent<InputManager>();

        OnGameBegins?.Invoke(); //Para que objetos agenos al Manager hagan sus cosas
        InicializeRounds();
        nActualRound = 0;
        actualRound = rounds[nActualRound];
        actualRound.Play();
    }

    private void Update()
    {
        if (!noMoreRounds)
        {
            if(actualRound != null && actualRound.InRound)
            {
                if(frameRound % 3 == 0) //Para no estar ejecutando la logica a cada frame
                {
                    if (actualRound.IsRoundFinished())
                    {
                        actualRound.InRound = false;
                        actualRound = null;
                        noMoreRounds = true;
                        frameRound = 0;
                        OnRoundFinished?.Invoke();
                    }
                }
                frameRound++;
            }
        }
        else
        {
            if(frameRound == 3)
            {
                OnGameWin?.Invoke();
            }
        }
    }

    private void InicializePlayer()
    {
        startPoint = transform.GetChild(0);
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (!p)
        {
            Instantiate(playerShip, startPoint.position, Quaternion.identity);
        }
        else
        {
            Destroy(p);
            Instantiate(playerShip, startPoint.position, Quaternion.identity);
        }
    }
    private void InicializeRounds()
    {
        foreach (Round item in rounds)
        {
            item.InicialiceRound();
        }
    }

    public void NextRound()//Se llama desde el Invoke
    {
        if(nActualRound < rounds.Count - 1)
        {
            nActualRound++;
            actualRound = rounds[nActualRound];
            actualRound.Play();
        }
        else
        {
            OnGameWin?.Invoke();
        }
    }


    public void ReloadGamePlay()
    {
        int sc = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sc);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void PlayerInput(bool t)
    {
        if (t)
        {
            input.ConnectInput();
        }
        else
        {
            input.DisconnectInput();
        }
    }
}
