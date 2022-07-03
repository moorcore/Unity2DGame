using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Sprite[] Sprites;
    public float size = 1.0f;
    public float minSize = 0.05f;
    public float maxSize = 0.15f;
    public float speed = 2.5f;
    public float maxLifetime = 30.0f;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _spriteRenderer.sprite = Sprites[Random.Range(0, Sprites.Length)];

        transform.eulerAngles = new Vector3(0, 0, Random.value * 360.0f);
        transform.localScale = Vector3.one * size;

        _rigidbody.mass = size;
    }

    public void SetTrajetory(Vector2 direction)
    {
        _rigidbody.AddForce(direction * speed);

        Destroy(gameObject, maxLifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectiles" && GetComponent<Renderer>().isVisible)
        {
            if ((size / 2.0f) > minSize)
            {
                FindObjectOfType<AudioManager>().Play("asteroidexplotion");
                Split();
                Split();
            }

            FindObjectOfType<GameManager>().AsteroidDestroyed(this);
            FindObjectOfType<AudioManager>().Play("asteroidexplotion");
            Destroy(gameObject);
        }
    }

    private void Split()
    {
        Vector2 position = transform.position;
        position += Random.insideUnitCircle * 0.5f;

        Asteroid splitted = Instantiate(this, position, transform.rotation);
        splitted.size = size / 2.0f;
        splitted.SetTrajetory(Random.insideUnitCircle.normalized * (speed * 3.0f));
    }
}
