using UnityEngine;

public class CharController : MonoBehaviour
{
    public float MovementSpeed = 1;
    public float JumpForce = 1;
    public ProjBehaviour ProjPrefab;
    public Transform LaunchOffset;

    private float Hitpoints;
    private float MaxHitpoints = 5;
    public HPBarBehaviour HPBar;

    public Animator anim;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        Hitpoints = MaxHitpoints;
        // HPBar.SetHealth(Hitpoints, MaxHitpoints);
    }

    private void Update()
    {
        var horizontalMovement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontalMovement, 0, 0) * Time.deltaTime * MovementSpeed;

        var verticalMovement = Input.GetAxis("Vertical");
        transform.position += new Vector3(0, verticalMovement, 0) * Time.deltaTime * MovementSpeed;

        // if (!Mathf.Approximately(0, horizontalMovement)) 
        // {
        //     transform.rotation = horizontalMovement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        // }

        // if (!Mathf.Approximately(0, verticalMovement)) 
        // {
        //     transform.rotation = horizontalMovement > 0 ? Quaternion.Euler(180, 0, 0) : Quaternion.identity;
        // }

        // if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f) {
        //     _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);

        //     FindObjectOfType<AudioManager>().Play("charJump");
        // }

        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            FindObjectOfType<AudioManager>().Play("projSound");
            Instantiate(ProjPrefab, LaunchOffset.position, transform.rotation);
        }

        // if (Input.GetKeyDown(KeyCode.B)) 
        // {
        //     FindObjectOfType<AudioManager>().Play("charTaunt");
        // }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        var enemy = collision.collider.GetComponent<EnemyBehaviour>();

        if (enemy) 
        {
            PlayerTakeHit(1);
        }
    }

    private void PlayerTakeHit(float damage)
    {
        Hitpoints -= damage;

        // HPBar.SetHealth(Hitpoints, MaxHitpoints);

        if (Hitpoints > 0) 
        {
            FindObjectOfType<AudioManager>().Play("enemySight");
        }
        
        if (Hitpoints <= 0) 
        {
            FindObjectOfType<AudioManager>().Play("enemyDeath");
            Destroy(gameObject);
        }
    }    
}
