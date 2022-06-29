using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    public float stopDistance = 0.1f;

    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    
    void Update() 
    {   
        if (Vector2.Distance(transform.position, target.position) > stopDistance) 
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
