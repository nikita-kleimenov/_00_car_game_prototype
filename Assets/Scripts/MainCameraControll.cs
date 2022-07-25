using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [ExecuteInEditMode]
public class MainCameraControll : MonoBehaviour
{

    [SerializeField] private Transform _carPosition;
    
    public float speed = 10f;
    public ChangeCameraView changeCamera;
    private float _timer;
    public Transform[] NextCar;
    int i = 0;
    // Update is called once per frame
    void LateUpdate()
    { 
        
        _timer += Time.deltaTime;
        Vector3 offset = FindObjectOfType<GameSettings>().CameraOffsetControll;
        transform.position = Vector3.Lerp(transform.position,_carPosition.position + offset, _timer);
        transform.LookAt(_carPosition.position);
        _timer = 0;
        
    }

    public void ChangeLookAtObject(){
        Debug.Log(i);
        _carPosition = NextCar[i];
        i++;
    }
}
