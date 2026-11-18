using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    [SerializeField]
    private bool isGrounded;
    public float inGroundDumping;
    
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    
    
    // Update is called once per frame
    void Update()
    {
        // Capture left and right direction
        if (Input.GetKey(KeyCode.A))
        {
            rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
        }
        
        else if (Input.GetKey(KeyCode.D))
        {
            rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
        }
        else if (isGrounded &&
                 (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)))
        {
            rb.linearVelocity = new Vector2
                (rb.linearVelocity.x, jumpSpeed);
            isGrounded = false;
        }
        /*else if(isGrounded)
        {
            rb.linearVelocity = rb.linearVelocity * 0.9f;
        }
        */
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }
}
