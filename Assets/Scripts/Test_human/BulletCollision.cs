using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
  
    public float ExplosionForce = 500f;
    private void OnCollisionEnter(Collision other) {
        Debug.Log(other.collider.gameObject.name);
        
        if(other.gameObject.GetComponent<Rigidbody>()){
            ActivateRagdoll ragdoll = other.gameObject.GetComponentInParent<ActivateRagdoll>();
            ragdoll.IsActiveRagdoll = true;
            other.gameObject.GetComponent<Rigidbody>().AddForce(-transform.right * ExplosionForce * Time.deltaTime, ForceMode.Impulse);
        }
        
    }
}
