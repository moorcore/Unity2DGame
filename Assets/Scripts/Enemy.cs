using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hitpoints;
    public float maxHitpoints = 5;
    public float speed;
    public float stopDistance = 0.1f;

    private Transform target;

    void Start()
    {
        hitpoints = maxHitpoints;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    public void TakeHit(float damage)
    {
        hitpoints -= damage;

        if (hitpoints > 0)
        {
            FindObjectOfType<AudioManager>().Play("enemySight");
        }

        if (hitpoints <= 0)
        {
            FindObjectOfType<GameManager>().EnemyDestroyed(this);
            FindObjectOfType<AudioManager>().Play("shipdestroyed");
            Destroy(gameObject);
        }
    }
}
