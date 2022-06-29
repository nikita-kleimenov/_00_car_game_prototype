using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCountOfWheels : MonoBehaviour
{

    [SerializeField] private int _countWheelsInsideFinish = 0;
   
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "wheel"){
            _countWheelsInsideFinish += 1;
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "wheel"){
            _countWheelsInsideFinish -= 1;
        }
        Debug.Log(_countWheelsInsideFinish);
    }
}
