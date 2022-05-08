using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour , ISubmitHandler, ICancelHandler, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent OnClick;
    public UnityEvent OnCancelClick;
    [SerializeField] Color normalColor;
    [SerializeField] Color pressedColor;
    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }
    public void PressedColor()
    {
        image.color = pressedColor;
    }
    public void NormalColor()
    {
        image.color = normalColor;
    }
    public void OnCancel(BaseEventData eventData)
    {
        Debug.Log("Cancel");
        OnCancelClick?.Invoke();
    }

    public void OnSubmit(BaseEventData eventData)
    {
        Debug.Log("Submit");
        OnClick?.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnClick?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnCancelClick?.Invoke();
    }
}
