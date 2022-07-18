using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonCust : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Action<bool> onPointer;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        onPointer?.Invoke(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        onPointer?.Invoke(false);
    }
}
