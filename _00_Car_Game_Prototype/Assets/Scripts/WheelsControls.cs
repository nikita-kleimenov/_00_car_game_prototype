using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelsControls : MonoBehaviour
{
    [SerializeField] private WheelCollider _wheelColliderFL;
    [SerializeField] private WheelCollider _wheelColliderFR;
    [SerializeField] private Slider _sliderControl;
    [SerializeField] private float _maxAngle = 45f;
    [SerializeField] private float _sensitivity;
    // Start is called before the first frame update
    void Start()
    {
        _sliderControl.value = _wheelColliderFL.steerAngle;
        _sliderControl.value = _wheelColliderFR.steerAngle;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeWheelColliderSteerAngle( float value){
        _wheelColliderFL.steerAngle = value ;
        _wheelColliderFR.steerAngle = value ;
    }
}
