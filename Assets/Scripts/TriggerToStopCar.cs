using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToStopCar : MonoBehaviour
{

    public StartToPlay BackWheels;
    public WheelsControls ForwardWheels;
    [SerializeField] float _breakTorque;
    private bool _isBreak = false;
    [SerializeField] private Rigidbody _carRB;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_isBreak){
            ForwardWheels.WheelColliderFL.brakeTorque = _breakTorque;
            ForwardWheels.WheelColliderFR.brakeTorque = _breakTorque;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "detectFinish"){
            // BackWheels.WheelColliderBL.brakeTorque = _breakTorque;
            // BackWheels.WheelColliderBR.brakeTorque = _breakTorque;
            BackWheels.CarWheels[2].brakeTorque = _breakTorque;
            BackWheels.CarWheels[3].brakeTorque = _breakTorque;
            _carRB.isKinematic = true;
            _isBreak = true;
            Debug.Log("FINISH");
        }
    }
}
