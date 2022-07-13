using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRagdoll : MonoBehaviour
{
    [SerializeField] private List<Rigidbody> _bodyParts = new List<Rigidbody>();
    public bool IsActiveRagdoll = false;
    
    public MoveToTarget moveToTarget;
    void Update()
    {
        ChangeRagdollStatus(IsActiveRagdoll);
    }

    private void ChangeRagdollStatus(bool status){
        
        if(status){
            foreach (var member in _bodyParts){
                member.isKinematic = false;
                member.detectCollisions = true;
                gameObject.GetComponent<Animation>().Stop("Walking");
                moveToTarget.enabled = false;
            }
        }
        else{
            foreach (var member in _bodyParts){
                member.isKinematic = true;
                member.detectCollisions = true;
                member.collisionDetectionMode = CollisionDetectionMode.Continuous;
                gameObject.GetComponent<Animation>().Play("Walking");
            }
        }
    }
}
