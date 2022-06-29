using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraControll : MonoBehaviour
{

    [SerializeField] private Transform _carPosition;
    private float _speed = 10f;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 offset = new Vector3(0, 11f, -5f);
        var targetPosition = _carPosition.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, _speed * Time.deltaTime);
        var direction = _carPosition.position - transform.position;
        var rotation = Quaternion.LookRotation(direction, Vector3.up);

        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _speed * Time.deltaTime);
        
    }
}
