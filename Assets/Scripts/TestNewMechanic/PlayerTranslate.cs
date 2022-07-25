// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// [ExecuteAlways]
// public class PlayerTranslate : MonoBehaviour
// {

//     public Transform PointA;
//     public Transform PointB;
//     public Transform Player;

//     private  float _timer;
//     public bool isRotate = false;
    
//     public Slider Translator;


//     void Update()
//     {
//         if(isRotate){
//         _timer += Time.deltaTime;
//         Player.position = Vector3.Lerp(PointA.position, PointB.position, _timer);
//         Player.rotation = Quaternion.Lerp(PointA.rotation, PointB.rotation, _timer);
//         }
//     }

//     public void ActivateRotate(){
//         isRotate = true;
//     }

   
// }
