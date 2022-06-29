using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool _isGameStarted = false;
    public void StartGame(){
        _isGameStarted = true;
    }
    
    public bool IsGameStarted(){
        return _isGameStarted;
    }
}
