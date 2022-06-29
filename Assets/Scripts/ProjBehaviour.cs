using UnityEngine;

public class ProjBehaviour : MonoBehaviour
{
    public float Speed = 7f;

    void Update()
    {
        transform.position += transform.up * Time.deltaTime * Speed;
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        var enemy = collision.collider.GetComponent<EnemyBehaviour>();
        FindObjectOfType<AudioManager>().Play("projHitSound");

        if (enemy) 
        {
            enemy.TakeHit(1);   
        }

        gameObject.SetActive(false);
    }
}
