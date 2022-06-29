using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    
    public float speed;

    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    
    void Update() 
    {   
        if (Vector2.Distance(transform.position, target.position) > 3) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        
    }
}
