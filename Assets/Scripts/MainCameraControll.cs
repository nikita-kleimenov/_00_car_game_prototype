using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraControll : MonoBehaviour
{

    [SerializeField] private Transform _carPosition;
    public float speed = 10f;
    public ChangeCameraView changeCamera;

    public Vector3 offset;
    // Update is called once per frame
    void FixedUpdate()
    {
        var targetPosition = _carPosition.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        var direction = _carPosition.position - transform.position;
        var rotation = Quaternion.LookRotation(direction, Vector3.up);
        if(changeCamera.isCameraRotate)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed * Time.deltaTime);
        }
            
        
    }
}
