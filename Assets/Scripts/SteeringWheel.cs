using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SteeringWheel : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private bool _wheelBeingHeld = false;
    public RectTransform Wheel;
    public float WheelAngle = 0f;
    public float LastWheelAngle = 0f;
    private Vector2 _center;
    public float ReleaseSpeed = 300f;
    public float OutPut;
    float MaxSteerAngle;

    private void Update() {
        MaxSteerAngle = FindObjectOfType<GameSettings>().SteeringWheelMaxAgnle;
        if(!_wheelBeingHeld && WheelAngle != 0){
           float deltaAngle = ReleaseSpeed * Time.deltaTime;
           if(Mathf.Abs(deltaAngle) > Mathf.Abs(WheelAngle)){
               WheelAngle = 0f;
           } 
           else if(WheelAngle > 0f){
               WheelAngle -= deltaAngle;
           }
           else{
               WheelAngle += deltaAngle;
           }
        }
        Wheel.localEulerAngles = new Vector3(0, 0, -WheelAngle);
        OutPut = WheelAngle / MaxSteerAngle;
    }
    public void OnPointerDown(PointerEventData data){
        _wheelBeingHeld = true;
        _center = RectTransformUtility.WorldToScreenPoint(data.pressEventCamera, Wheel.position);
        LastWheelAngle = Vector2.Angle(Vector2.up, data.position - _center);
    }   

    public void OnDrag(PointerEventData data){
        float newAngle = Vector2.Angle(Vector2.up, data.position - _center);
        if((data.position - _center).sqrMagnitude >= 400){
            if(data.position.x > _center.x){
                WheelAngle += newAngle - LastWheelAngle;
            }
            else{
                WheelAngle -= newAngle - LastWheelAngle;
            }
        }
        WheelAngle = Mathf.Clamp(WheelAngle, -MaxSteerAngle, MaxSteerAngle);
        LastWheelAngle = newAngle;
    }
    public void OnPointerUp(PointerEventData data){
        _wheelBeingHeld = false; 
    }
}
