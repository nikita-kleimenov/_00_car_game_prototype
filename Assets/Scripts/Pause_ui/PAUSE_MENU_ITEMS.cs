using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PAUSE_MENU_ITEMS : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public void OnPointerEnter(PointerEventData eventData){
      
            gameObject.transform.localScale *= 1.1f;
    }
     public void OnPointerExit(PointerEventData eventData){
      
            gameObject.transform.localScale /= 1.1f;
    }
}
