using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPowerUp : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private int points = 10;
    [SerializeField] private int movSpeed = 10;
    AudioSource source;
    Collider col;
    MeshRenderer rend;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        col = GetComponent<Collider>();
        rend = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        transform.Translate(Vector3.back * movSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (weapon)
            {
                WeaponManager wm = other.GetComponent<WeaponManager>();
                wm.AddWeapon(weapon);
                ScoreManager.Instance.AddScorePoints(points);
                source.Play();
                StartCoroutine(WaitToDisable());
            }
        }
    }
    IEnumerator WaitToDisable()
    {
        col.enabled = false;
        rend.enabled = false;
        yield return new WaitForSeconds(0.3f);
        gameObject.SetActive(false);
    }
}
