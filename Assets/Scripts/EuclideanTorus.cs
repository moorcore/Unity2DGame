using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EuclideanTorus : MonoBehaviour
{
    void Update () 
    {
        if (transform.position.x > 18)
        {
 
            transform.position = new Vector3(-18, transform.position.y, 0);
 
        }
        else if (transform.position.x < -18) 
        {
            transform.position = new Vector3(18, transform.position.y, 0);
        }
 
        else if (transform.position.y > 11) 
        {
            transform.position = new Vector3(transform.position.x, -11, 0);
        }
 
        else if (transform.position.y < -11)
        {
            transform.position = new Vector3(transform.position.x, 11, 0);
        }
    }
}
