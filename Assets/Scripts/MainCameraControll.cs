using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MainCameraControll : MonoBehaviour
{

    [SerializeField] private Transform _carPosition;
    
    public float speed = 10f;
    public ChangeCameraView changeCamera;

    public Vector3 offset;
    // Update is called once per frame
    void LateUpdate()
    {
        var targetPosition = _carPosition.TransformPoint(offset);
        // transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        transform.position = _carPosition.position + offset;
        var direction = _carPosition.position - transform.position;
        var rotation = Quaternion.LookRotation(direction, Vector3.up);
        if(changeCamera.isCameraRotate)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed * Time.deltaTime);
        }
        transform.LookAt(_carPosition.position);
        
    }
}
