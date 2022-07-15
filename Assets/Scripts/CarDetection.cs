using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDetection : MonoBehaviour
{
    [SerializeField] private GameObject _loosePanel;
    public float ExplosionForce = 500f;
    [SerializeField] private Vector3 directionOfImpact;
    [SerializeField] private float _speed;

    private void Awake() {
        _loosePanel.SetActive(false);
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.GetComponent<Rigidbody>()){
            Time.timeScale = 0.4f;
            ActivateRagdoll ragdoll = other.gameObject.GetComponentInParent<ActivateRagdoll>();
            ragdoll.IsActiveRagdoll = true;
            other.gameObject.GetComponent<Rigidbody>().AddForce(directionOfImpact * ExplosionForce + transform.forward, ForceMode.Impulse);
            StartCoroutine(SlowMotion());
        }
        StartToPlay carWheels = GameObject.FindObjectOfType<StartToPlay>();
        foreach (var wheel in carWheels.CarWheels)
        {
            wheel.brakeTorque = 5000;
        }        
        StartCoroutine(ShowLoosePanel());
    }

    IEnumerator SlowMotion(){
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 1f;
    }
    IEnumerator ShowLoosePanel(){
        yield return new WaitForSeconds(5f);
        _loosePanel.SetActive(true);
        _loosePanel.GetComponent<Animation>().Play("LoosePanelAnim");
        yield return new WaitForSeconds (5f);
        _loosePanel.GetComponent<Animation>().enabled = false;
    }
}
