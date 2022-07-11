using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraView : MonoBehaviour
{
    public MainCameraControll cameraControll;
    public bool isMainCameraControlActive =  true;
    public bool isCameraRotate = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if(!isMainCameraControlActive)
        {
            cameraControll.enabled = false;
        }
    }
}
