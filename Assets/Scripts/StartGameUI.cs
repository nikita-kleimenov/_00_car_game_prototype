using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartGameUI : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData pointerEvent){
        LevelManager levelManager = GameObject.FindObjectOfType<LevelManager>();
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().StartGame();
        levelManager.StartLevel();
        Debug.Log("restart lvl");
    }
}

