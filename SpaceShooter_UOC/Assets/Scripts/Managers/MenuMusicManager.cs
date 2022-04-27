using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuMusicManager : MonoBehaviour
{
    AudioSource source;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "GameplayScene")
        {
            Destroy(gameObject);
        }
    }

}
