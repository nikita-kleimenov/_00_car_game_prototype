using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Human))]
public class HumanTrigger : TriggerListener
{
    private Human human;

    private void Awake()
    {
        human = GetComponent<Human>();
    }

    public override void OnObjEnter(GameObject obj, GameObject trigger)
    {
        if (obj == gameObject || obj.transform.IsChildOf(transform))
            return;
        human.Die();
    }

    public override void OnObjExit(GameObject obj, GameObject trigger)
    {

    }
    public override void OnObjStay()
    {

    }
}
