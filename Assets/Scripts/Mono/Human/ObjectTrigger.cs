using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTrigger : MonoBehaviour
{
    [SerializeField] private TriggerListener Listener;


    private void OnCollisionEnter(Collision collision)
    {
        if (Listener.GetLayerMask != (Listener.GetLayerMask | (1 << collision.gameObject.layer)))
            return;
        if (Listener.GetTags.Contains(collision.transform.tag))
        {
            Listener?.OnContactEnter(collision.gameObject, gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (Listener.GetLayerMask != (Listener.GetLayerMask | (1 << other.gameObject.layer)))
            return;
        if (Listener.GetTags.Contains(other.tag))
        {
            Listener?.OnContactEnter(other.gameObject, gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (Listener.GetLayerMask != (Listener.GetLayerMask | (1 << collision.gameObject.layer)))
            return;
        if (Listener.GetTags.Contains(collision.transform.tag))
        {
            Listener?.OnContactExit(collision.gameObject, gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (Listener.GetLayerMask != (Listener.GetLayerMask | (1 << other.gameObject.layer)))
            return;
        if (Listener.GetTags.Contains(other.tag))
        {
            Listener?.OnContactExit(other.gameObject, gameObject);
        }
    }
}