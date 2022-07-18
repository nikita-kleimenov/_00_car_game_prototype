using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angle: MonoBehaviour{
   public float WheelAngle;
   
   private void Update() {
    WheelAngle = WheelAngle = FindObjectOfType<CarAlternativeController>().Angle;
    Debug.Log(WheelAngle);
   }
}
