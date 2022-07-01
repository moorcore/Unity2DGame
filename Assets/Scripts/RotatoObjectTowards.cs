using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatoObjectTowards : MonoBehaviour
{
    public Transform spaceship;
    public float radius;
    public float speed = 5f;
 
    private Transform pivot;
 
    void Start()
    {
        pivot = spaceship.transform;
        transform.parent = pivot;
        transform.position += Vector3.up * radius;
    }
 
    void Update()
    {
        Vector3 shipVector = Camera.main.WorldToScreenPoint(spaceship.position);
        shipVector = Input.mousePosition - shipVector;
        float angle = Mathf.Atan2(shipVector.y, shipVector.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }
}
