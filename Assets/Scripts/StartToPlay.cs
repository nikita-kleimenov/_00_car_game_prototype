using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartToPlay : MonoBehaviour
{
    // Объект transform самих моделей колес
    [SerializeField] private Transform _wheelTransformFL;
    [SerializeField] private Transform _wheelTransformFR;
    [SerializeField] private Transform _wheelTransformBL;
    [SerializeField] private Transform _wheelTransformBR;
   

    public List<WheelCollider> CarWheels = new List<WheelCollider>();
    [SerializeField] private float _forceTorqueOfWheel;
    [SerializeField] private StartBtn _startBtn;

    private void Start() {
        _startBtn.enabled = true;
    }

    public void OnTapToPlay()
    {
        foreach (var wheel in CarWheels)
        {
            wheel.motorTorque = _forceTorqueOfWheel;
        }
        _startBtn.enabled = false;
    }
}
