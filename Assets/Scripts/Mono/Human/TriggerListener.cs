using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TriggerListener : MonoBehaviour
{

    [Header("Settings")]
    [SerializeField] protected ColliderType Type;
    protected enum ColliderType { Mesh, Point };
    [SerializeField] private List<string> TagList;
    [SerializeField] private LayerMask Layers;

    public List<string> GetTags => TagList;
    public LayerMask GetLayerMask => Layers;

    [SerializeField] protected List<GameObject> Contacts = new List<GameObject>();
    protected Dictionary<GameObject, int> Count = new Dictionary<GameObject, int>();

    public void OnContactEnter(GameObject obj, GameObject trigger)
    {
        if (!Contacts.Contains(obj))
        {
            Contacts.Add(obj);
            Count.Add(obj, 0);

            OnObjEnter(obj, trigger);
        }
        if (Count.ContainsKey(obj))
        {
            Count[obj]++;
        }
    }
    public void OnContactExit(GameObject obj, GameObject trigger)
    {
        if (Contacts.Contains(obj))
        {
            Count[obj]--;

            if (Count[obj] <= 0)
            {
                Count.Remove(obj);
                Contacts.Remove(obj);

                OnObjExit(obj, trigger);
            }
        }
    }

    public abstract void OnObjEnter(GameObject obj, GameObject trigger);
    public abstract void OnObjExit(GameObject obj, GameObject trigger);
    public abstract void OnObjStay();
    public void ClearContacts()
    {
        Contacts.Clear();
        Count.Clear();
    }
    private void Execute()
    {

    }


    private void FixedUpdate() => Execute();
}