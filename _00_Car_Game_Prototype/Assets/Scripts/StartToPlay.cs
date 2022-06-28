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
    // Коллайдеры колес
    [SerializeField] private WheelCollider _wheelColliderFL;
    [SerializeField] private WheelCollider _wheelColliderFR;
    [SerializeField] private WheelCollider _wheelColliderBL;
    [SerializeField] private WheelCollider _wheelColliderBR;

    [SerializeField] private float _forceTorqueOfWheel;
    [SerializeField] private StartBtn _startBtn;

    private void Start() {
        _startBtn.enabled = true;
    }

    public void OnTapToPlay()
    {
        _wheelColliderBL.motorTorque = _forceTorqueOfWheel;
        _wheelColliderBR.motorTorque = _forceTorqueOfWheel;
        Debug.Log("Tap to start");
        _startBtn.enabled = false;
    }
}
