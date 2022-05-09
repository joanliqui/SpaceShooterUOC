using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour, IDamagable
{
    [SerializeField] private int maxLife;
    private int cntLife;
    private Collider col;
    private GameObject mesh;
    [SerializeField] GameObject explosionParticlePrefab;
    [SerializeField] AudioSource explosionSource;

    [Header("UI")]
    [SerializeField] GameObject layout;
    [SerializeField] GameObject uiLifePrefab;
    private List<GameObject> lifesUI = new List<GameObject>();

    public int CntLife { get => cntLife; private set => cntLife = value; }

    public void Damaged(int damage)
    {
        if(cntLife > 1)
        {
            cntLife--;
            Debug.Log(cntLife);
        }
        else 
        {
            Debug.Log("Muertooo");
            Destroyed();
        }
        UpdateLifeUI();
    }

    public void Destroyed()
    {
        GameManager.Instance.OnGameLose?.Invoke(); //Desactiva Input y Activa Panel de Lose
        col.enabled = false;
        mesh.SetActive(false);
        Instantiate(explosionParticlePrefab, transform.position, Quaternion.identity);
        if(explosionSource)
            explosionSource.Play();
    }

    void Start()
    {
        cntLife = maxLife;
        col = GetComponent<Collider>();
        mesh = transform.GetChild(0).gameObject;

        InicializaeUI();
    }

    void InicializaeUI()
    {
        for (int i = 0; i < maxLife; i++)
        {
            lifesUI.Add(Instantiate(uiLifePrefab, layout.transform));
        }
    }

    private void UpdateLifeUI()
    {
        for (int i = 0; i < maxLife; i++)
        {
            if(i < cntLife)
            {
                lifesUI[i].SetActive(true);
            }
            else
            {
                lifesUI[i].SetActive(false);
            }
        }
    }

}
