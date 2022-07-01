using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Sprite[] Sprites;
    public float size = 1.0f;
    public float minSize = 0.5f;
    public float maxSize = 1.5f;
    public float speed = 2.5f;

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
    }
}
