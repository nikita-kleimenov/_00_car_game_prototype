using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Camera cameraGame;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private GameObject _bulletPrefab;
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 400f, Color.yellow);
        
         if(Input.GetMouseButtonDown(0)){  
        BulletGenerator(ray);
        }
  
        RaycastHit hit;
        
        if(Physics.Raycast(ray, out hit)){
            
        } 
    }

    private void BulletGenerator(Ray ray){
            GameObject newBulletPrefab = Instantiate(_bulletPrefab, ray.origin, Quaternion.identity);
            newBulletPrefab.GetComponent<Rigidbody>().AddForce(ray.direction * _bulletSpeed, ForceMode.VelocityChange);      
        }
      
}
