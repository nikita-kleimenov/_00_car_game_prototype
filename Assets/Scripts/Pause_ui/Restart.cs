using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Restart : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData pointerEvent){
        Resume resume = GameObject.FindObjectOfType<Resume>();
        resume.CloseAndContinue();
        LevelManager levelManager = GameObject.FindObjectOfType<LevelManager>();
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().StartGame();
        levelManager.RestartLevel();
    }
}
