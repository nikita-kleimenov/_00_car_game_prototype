using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Resume : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _pauseIcon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData pointerEvent){
        CloseAndContinue();
    }

    public void CloseAndContinue(){ 
        _pausePanel.SetActive(false);
        _pauseIcon.SetActive(true);
        Time.timeScale = 1;
    }
}
