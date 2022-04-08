using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUIHolder : MonoBehaviour
{
    private Image image;
    private bool isEmpty = true;

    public bool IsEmpty { get => isEmpty; set => isEmpty = value; }

    public void Start()
    {
        image = transform.GetChild(0).GetComponent<Image>();
    }

    public void SwitchWeaponImage(Sprite sprite)
    {
        image.sprite = sprite;
    }
}
