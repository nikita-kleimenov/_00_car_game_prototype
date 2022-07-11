using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDetection : MonoBehaviour
{
    [SerializeField] private GameObject _loosePanel;


    private void Awake() {
        _loosePanel.SetActive(false);
    }
    private void OnCollisionEnter(Collision other) {
        Debug.Log("CRACH");
        StartToPlay carWheels = GameObject.FindObjectOfType<StartToPlay>();
        foreach (var wheel in carWheels.CarWheels)
        {
            wheel.brakeTorque = 5000;
        }        
        StartCoroutine(ShowLoosePanel());
    }

    IEnumerator ShowLoosePanel(){
        yield return new WaitForSeconds(0.5f);
        _loosePanel.SetActive(true);
        _loosePanel.GetComponent<Animation>().Play("LoosePanelAnim");
        yield return new WaitForSeconds (0.2f);
        _loosePanel.GetComponent<Animation>().enabled = false;
    }
}
