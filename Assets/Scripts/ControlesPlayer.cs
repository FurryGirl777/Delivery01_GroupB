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
    

    public int jumpCount;
    public int maxJumps;
    
    private Animator animator;

    public InputActionReference move;
    public InputActionReference jump;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        dir = move.action.ReadValue<Vector2>();
        animator.SetBool("isGrounded", isGrounded);

        float speed = Mathf.Abs(dir.x); 
        animator.SetFloat("Speed", speed);

        if (dir.x > 0) 
        {
            transform.localScale = new Vector3(-0.8f, 0.8f, 0.8f); 
        }
        else if (dir.x < 0) 
        {
            transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        }


    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(dir.x * moveSpeed, rb.linearVelocity.y);
    }

    private void OnEnable()
    {
        jump.action.started += Jump;
    }

    private void OnDisable()
    {
        jump.action.started -= Jump;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCount = 0; 
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void Jump(InputAction.CallbackContext obj)
    {
        if (jumpCount <= maxJumps)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumpCount++;
        }
    }
}
 
