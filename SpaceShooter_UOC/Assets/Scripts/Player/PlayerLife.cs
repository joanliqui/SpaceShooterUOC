using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour, IDamagable
{
    [SerializeField] private int maxLife;
    private int cntLife;
    private Collider col;
    private GameObject mesh;
    [SerializeField] GameObject explosionParticlePrefab;
    [SerializeField] AudioSource explosionSource;
    


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
        
    }

}
