using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelsControls : MonoBehaviour
{
    [SerializeField] private WheelCollider _wheelColliderFL;
    [SerializeField] private WheelCollider _wheelColliderFR;
    [SerializeField] private Transform _wheelModelFR;
    [SerializeField] private Transform _wheelModelFL;
    [SerializeField] private Slider _sliderControl;
    [SerializeField] private float _maxAngle = 45f;
    [SerializeField] private float _sensitivity;
    public SteeringWheel steeringWheel;
    // Start is called before the first frame update
    void Start()
    {
        _sliderControl.value = _wheelColliderFL.steerAngle;
        _sliderControl.value = _wheelColliderFR.steerAngle;
    }

    // Update is called once per frame
    void Update()
    {
        _wheelColliderFL.steerAngle = steeringWheel.WheelAngle;
        if(_wheelColliderFL.steerAngle > _maxAngle){
            _wheelColliderFL.steerAngle = _maxAngle;
        }
        else if(_wheelColliderFL.steerAngle < -_maxAngle){
            _wheelColliderFL.steerAngle = -_maxAngle;
        }
        _wheelColliderFR.steerAngle = steeringWheel.WheelAngle;
        if(_wheelColliderFR.steerAngle > _maxAngle){
            _wheelColliderFR.steerAngle = _maxAngle;
        }
         else if(_wheelColliderFR.steerAngle < -_maxAngle){
            _wheelColliderFR.steerAngle = -_maxAngle;
        }
        RotateWheel(_wheelColliderFL, _wheelModelFL);
        RotateWheel(_wheelColliderFR, _wheelModelFR);
    }

    private void RotateWheel(WheelCollider collider, Transform transform){
        Vector3 position;
        Quaternion rotation;

        collider.GetWorldPose(out position, out rotation);
        transform.rotation = rotation;
        transform.position = position;
    }
}
