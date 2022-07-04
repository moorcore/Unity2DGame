using UnityEngine;

public class Laser : MonoBehaviour
{
    public float delay = 0.2f;

    private void Start()
    {
        transform.position += transform.up;
    }

    void Update()
    {
        Destroy(gameObject, delay);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.collider.GetComponent<Enemy>();

        if (enemy)
        {
            enemy.TakeHit(20);
        }
    }
}
