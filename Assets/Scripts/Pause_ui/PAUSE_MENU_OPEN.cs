using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PAUSE_MENU_OPEN : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField] private GameObject _pausePanel;
    // Start is called before the first frame update
    void Start()
    {
        _pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData pointerEvent){
        _pausePanel.SetActive(true);
        Time.timeScale = 0;
        gameObject.SetActive(false);
    }
    
    public void OnPointerEnter(PointerEventData pointerEvent){
        gameObject.transform.localScale = Vector3.one * 1.1f;
    }

     public void OnPointerExit(PointerEventData pointerEvent){
        gameObject.transform.localScale = Vector3.one;
    }
}
