using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProvider : MonoBehaviour
{

    [SerializeField] List<ScoreSO> levelsData;
    [SerializeField] List<LevelSO> levelsRounds;

    LevelSO levelToProvide;
    int cntLevel;

    static LevelProvider instace;

    #region PROPIEDADES
    public static LevelProvider Instace { get => instace; }
    public int CntLevel { get => cntLevel + 1; set => cntLevel = value; }
    public List<ScoreSO> LevelsData { get => levelsData; set => levelsData = value; }
    #endregion
    // Start is called before the first frame update
    void Awake()
    {
        if(instace == null)
        {
            instace = this;
            levelToProvide = levelsRounds[0]; //Ponemos el nivel 1 por defecto
            DontDestroyOnLoad(gameObject);
        }
        else if(instace != this)
        {
            Destroy(gameObject);
        }
        
    }


    public void SetLevelToProvide(int level)
    {
        cntLevel = level - 1;
        levelToProvide = levelsRounds[cntLevel];
    }

    public LevelSO GetLevel()
    {
        return levelToProvide;
    }
}
