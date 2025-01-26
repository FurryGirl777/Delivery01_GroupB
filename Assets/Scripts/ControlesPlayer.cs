using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlesPlayer : MonoBehaviour
{
    public Rigidbody2D rb;

    public float moveSpeed;
    private Vector2 dir;
    public float jumpForce;
    private bool isGrounded;
    private float _horizontalDir;
    private bool powerUp = false;

    public int jumpCount;
    public int maxJumps;
    
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(_horizontalDir)); 
        animator.SetBool("isGrounded", isGrounded);

        if (_horizontalDir > 0) 
        {
            transform.localScale = new Vector3(-0.8f, 0.8f, 0.8f); 
        }
        else if (_horizontalDir < 0) 
        {
            transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(dir.x * moveSpeed, rb.linearVelocity.y);
        Vector2 velocity = rb.linearVelocity;
        velocity.x = _horizontalDir * moveSpeed;
        rb.linearVelocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCount = 0; 
        }
    }

    private void OnEnable()
    {
        PowerUp.OnPowerUp += UpdateBool;
    }

    private void OnDisable()
    {
        PowerUp.OnPowerUp -= UpdateBool;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnMove(InputValue value)
    {
        var inputVal = value.Get<Vector2>();
        _horizontalDir = inputVal.x;
    }

    private void OnJump(InputValue value)
    {
        if (jumpCount <= maxJumps)
        {
            if (powerUp)
            {
                rb.AddForce(new Vector2(0f, jumpForce + 4), ForceMode2D.Impulse);
                powerUp = false;
            }
            else
            {
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }
            jumpCount++;
        }
    }

    private void UpdateBool(PowerUp power)
    {
        powerUp = true;
    }
}
 
