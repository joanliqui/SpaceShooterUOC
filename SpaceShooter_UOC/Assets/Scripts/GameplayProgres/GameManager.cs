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
    [SerializeField] LevelSO level;
    private List<Round> rounds;
    int nActualRound;
    Round actualRound;
    int frameRound;
    [SerializeField] UnityEvent OnGameBegins;
    [SerializeField] UnityEvent OnRoundFinished;
    [SerializeField] public UnityEvent OnGameWin;
    [SerializeField] public UnityEvent OnGameLose;
    //LEVEL
    int cntLevel;

    [Header("Spawners")]
    [SerializeField] List<Spawner> spawnersPrefabs;
    [SerializeField] Spawner simpleEnemySpawner;
    [SerializeField] Spawner meteorSpawner, sinusEnemySpawner;
    private Dictionary<SpawnerEnum, GameObject> spawnerDictionary;
    [SerializeField] Transform spawnerInitPos;
    //[SerializeField] Transform spawnerParent;


    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
  
        //InicializePlayer();
        InstantiateSpawners();
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

    private void InstantiateSpawners()
    {
        spawnerDictionary = new Dictionary<SpawnerEnum, GameObject>();
        GameObject go = Instantiate(simpleEnemySpawner.gameObject, spawnerInitPos.position, spawnerInitPos.rotation);
        spawnerDictionary.Add(SpawnerEnum.SIMPLE_ENEMY, go);
        go = Instantiate(meteorSpawner.gameObject, spawnerInitPos.position, spawnerInitPos.rotation);
        spawnerDictionary.Add(SpawnerEnum.METEOR, go);
        go = Instantiate(sinusEnemySpawner.gameObject, spawnerInitPos.position, spawnerInitPos.rotation);
        spawnerDictionary.Add(SpawnerEnum.SINUS_ENEMY, go);


    }

    public void SetLevel()
    {
        cntLevel = LevelProvider.Instace.CntLevel;
        level = LevelProvider.Instace.GetLevel();
    } 

    public Spawner GetSpawner(SpawnerEnum spawnerType)
    {
        spawnerDictionary.TryGetValue(spawnerType, out GameObject spawner);
        Spawner s = spawner.GetComponent<Spawner>();

        return s;

    }

    private void Update()
    {
        
        if(actualRound != null && actualRound.InRound)
        {
            if(frameRound % 3 == 0) //Para no estar ejecutando la logica a cada frame
            {
                if (actualRound.IsRoundFinished())
                {
                    actualRound.InRound = false;
                    actualRound = null;
                    frameRound = 0;
                    OnRoundFinished?.Invoke();
                }
            }
            frameRound++;
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
        if(level != null)
        {
            rounds = level.rounds;
        }

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

    public void NextLevel()
    {
        LevelProvider.Instace.SetLevelToProvide(cntLevel + 1);
        ReloadGamePlay();
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
