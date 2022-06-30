using System.Collections;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public float MovementSpeed = 1;
    public float JumpForce = 1;
    public ProjBehaviour ProjPrefab;
    public Transform LaunchOffset;
    public Transform Spaceship;

    private float Hitpoints;
    private float MaxHitpoints = 5;
    public HPBarBehaviour HPBar;

    public bool CanDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    [SerializeField]
    private TrailRenderer trailRenderer;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        Hitpoints = MaxHitpoints;
        // HPBar.SetHealth(Hitpoints, MaxHitpoints);
    }

    private void Update()
    {
/*        if (isDashing)
        {
            return;
        }*/

        var horizontalMovement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontalMovement, 0, 0) * Time.deltaTime * MovementSpeed;

        var verticalMovement = Input.GetAxis("Vertical");
        transform.position += new Vector3(0, verticalMovement, 0) * Time.deltaTime * MovementSpeed;

        if (Input.GetButtonDown("Jump") && CanDash) 
        {
            StartCoroutine(Dash());

            FindObjectOfType<AudioManager>().Play("dash");
        }

        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            FindObjectOfType<AudioManager>().Play("projSound");

            GameObject proj = ObjectPool.instance.GetPooledObject();
            if (proj != null)
            {
                proj.transform.position = LaunchOffset.position;
                proj.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.B)) 
        {
            FindObjectOfType<AudioManager>().Play("charTaunt");
        }
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
    
    private IEnumerator Dash()
    {
        CanDash = false;
        isDashing = true;
        Vector2 originalVelocity = _rigidbody.velocity;

        Vector3 shipVector = Camera.main.WorldToScreenPoint(Spaceship.position);
        shipVector = Input.mousePosition - shipVector;


        _rigidbody.velocity = new Vector3(transform.localScale.x * dashingPower,
            transform.localScale.y * dashingPower);
        trailRenderer.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        trailRenderer.emitting = false;
        _rigidbody.velocity = originalVelocity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        CanDash = true;
    }
}
