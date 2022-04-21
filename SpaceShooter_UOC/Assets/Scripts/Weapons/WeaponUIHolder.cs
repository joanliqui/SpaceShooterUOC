using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUIHolder : MonoBehaviour
{
    private Image image;
    private bool isEmpty = true;

    public bool IsEmpty { get => isEmpty; set => isEmpty = value; }

    public void Awake()
    {
        image = transform.GetChild(0).GetComponent<Image>();
    }

    public void SwitchWeaponImage(Sprite sprite)
    {
        if (isEmpty)
        {
            image.enabled = false;
            return;
        }
        else
        {
            image.enabled = true;
        }
        image.sprite = sprite;
    }

}
