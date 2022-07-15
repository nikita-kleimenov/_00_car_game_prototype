using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelsControls : MonoBehaviour
{
    public WheelCollider WheelColliderFL;
    public WheelCollider WheelColliderFR;
     public WheelCollider WheelColliderBL;
    public WheelCollider WheelColliderBR;
    [SerializeField] private Transform _wheelModelFR;
    [SerializeField] private Transform _wheelModelFL;
    [SerializeField] private Transform _wheelModelBR;
    [SerializeField] private Transform _wheelModelBL;
    [SerializeField] private Slider _sliderControl;
    // [SerializeField] private float _maxAngle = 45f;
    [SerializeField] private float _sensitivity;
    public SteeringWheel steeringWheel;
    public GameObject CenterOfSteeringWheel;
    
    public Transform SteeringWheelModel;

    

    // Update is called once per frame
    void Update()
    {
        float maxAngle = FindObjectOfType<GameSettings>().MaxCarWheelsAngle;
        WheelColliderFL.steerAngle = steeringWheel.WheelAngle;
        SteeringWheelModel.localEulerAngles = new Vector3(0, steeringWheel.WheelAngle, 0f);
        if(WheelColliderFL.steerAngle > maxAngle){
            WheelColliderFL.steerAngle = maxAngle;
        }
        else if(WheelColliderFL.steerAngle < -maxAngle){
            WheelColliderFL.steerAngle = -maxAngle;
        }
        WheelColliderFR.steerAngle = steeringWheel.WheelAngle;
        if(WheelColliderFR.steerAngle > maxAngle){
            WheelColliderFR.steerAngle = maxAngle;
        }
         else if(WheelColliderFR.steerAngle < -maxAngle){
            WheelColliderFR.steerAngle = -maxAngle;
        }
        RotateWheel(WheelColliderFL, _wheelModelFL);
        RotateWheel(WheelColliderFR, _wheelModelFR);
        RotateWheel(WheelColliderBL, _wheelModelBL);
        RotateWheel(WheelColliderBR, _wheelModelBR);
    }

    private void RotateWheel(WheelCollider collider, Transform transform){
        Vector3 position;
        Quaternion rotation;

        collider.GetWorldPose(out position, out rotation);
        transform.rotation = rotation;
        transform.position = position;
    }
}
