using UnityEngine;

public class ProjBehaviour : MonoBehaviour
{
    public float speed = 7.0f;
    public float maxLifetime = 5.0f;

    void Update()
    {
        transform.position += transform.up * Time.deltaTime * speed;
        if (!GetComponent<Renderer>().isVisible)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.collider.GetComponent<Enemy>();
        FindObjectOfType<AudioManager>().Play("projHitSound");

        if (enemy)
        {
            enemy.TakeHit(1);
        }

        gameObject.SetActive(false);
    }
}
