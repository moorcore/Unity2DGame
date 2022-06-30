using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatoObjectTowards : MonoBehaviour
{
    public Transform Spaceship;
    public float Radius;
    public float Speed = 5f;
 
    private Transform pivot;
 
    void Start()
    {
        pivot = Spaceship.transform;
        transform.parent = pivot;
        transform.position += Vector3.up * Radius;
    }
 
    void Update()
    {
        Vector3 shipVector = Camera.main.WorldToScreenPoint(Spaceship.position);
        shipVector = Input.mousePosition - shipVector;
        float angle = Mathf.Atan2(shipVector.y, shipVector.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Speed * Time.deltaTime);
    }
}
