using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelsControls : MonoBehaviour
{
    public WheelCollider WheelColliderFL;
    public WheelCollider WheelColliderFR;
    [SerializeField] private Transform _wheelModelFR;
    [SerializeField] private Transform _wheelModelFL;
    [SerializeField] private Slider _sliderControl;
    [SerializeField] private float _maxAngle = 45f;
    [SerializeField] private float _sensitivity;
    public SteeringWheel steeringWheel;
    public GameObject CenterOfSteeringWheel;
    
    public Transform SteeringWheelModel;

    

    // Update is called once per frame
    void Update()
    {
        WheelColliderFL.steerAngle = steeringWheel.WheelAngle;
        SteeringWheelModel.localEulerAngles = new Vector3(0, steeringWheel.WheelAngle, 0f);
        if(WheelColliderFL.steerAngle > _maxAngle){
            WheelColliderFL.steerAngle = _maxAngle;
        }
        else if(WheelColliderFL.steerAngle < -_maxAngle){
            WheelColliderFL.steerAngle = -_maxAngle;
        }
        WheelColliderFR.steerAngle = steeringWheel.WheelAngle;
        if(WheelColliderFR.steerAngle > _maxAngle){
            WheelColliderFR.steerAngle = _maxAngle;
        }
         else if(WheelColliderFR.steerAngle < -_maxAngle){
            WheelColliderFR.steerAngle = -_maxAngle;
        }
        RotateWheel(WheelColliderFL, _wheelModelFL);
        RotateWheel(WheelColliderFR, _wheelModelFR);
    }

    private void RotateWheel(WheelCollider collider, Transform transform){
        Vector3 position;
        Quaternion rotation;

        collider.GetWorldPose(out position, out rotation);
        transform.rotation = rotation;
        transform.position = position;
    }
}
