using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CarAlternativeController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool _isPressed = false;
    [SerializeField] private bool _isLeft;
    public GameObject RigthButton;
    public GameObject LeftButton; 
    public float Angle;
    public void OnPointerDown(PointerEventData pointerEvent){
        _isPressed = true;
    }
    public void OnPointerUp(PointerEventData pointerEvent){
        _isPressed = false;
    }

    private void LateUpdate() {
        float maxAngle = FindObjectOfType<GameSettings>().MaxCarWheelsAngle;
        if(_isPressed && this.gameObject.tag == "LeftArrow"){
            RigthButton.GetComponent<CarAlternativeController>().enabled = false;
            Debug.Log("Left arrow");
            Angle -= Time.deltaTime * 100f;
                if(Angle < -maxAngle){
                Angle = -maxAngle;
                }    
        }
        else if(_isPressed){
            LeftButton.GetComponent<CarAlternativeController>().enabled = false;
            Angle += Time.deltaTime * 100f;
            Debug.Log("pressed rigth");
            if(Angle > maxAngle){
            Angle = maxAngle;
        }
       } 
       if(!_isPressed){
            if(LeftButton.GetComponent<CarAlternativeController>().enabled == false){
                LeftButton.GetComponent<CarAlternativeController>().enabled = true;
            }
             if(RigthButton.GetComponent<CarAlternativeController>().enabled == false){
                RigthButton.GetComponent<CarAlternativeController>().enabled = true;
            }
            if(Angle > 0){
                Angle -= Time.deltaTime * 100f;
                    if(Angle <= 0){
                        Angle = 0;
                    }
            }
            else{
                Angle += Time.deltaTime * 100f;
                    if(Angle >= 0){
                        Angle = 0;
                    }
            }
       }
    }
}
