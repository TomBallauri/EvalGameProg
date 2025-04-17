using UnityEngine;

public class MovementController : MonoBehaviour
{
    private Rigidbody2D rb;
    private string direction;
    private bool jump = false;
    private bool isJumping = false;

    [SerializeField]
    private float movementSpeed = 1f;

    [SerializeField]
    private float jumpForce = 7f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q))
        {
            direction = "left";
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            direction = "right";
        }
        else
        {
            direction = null;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        if (direction == "right")
        {
            rb.AddForce(new Vector2(movementSpeed, 0), ForceMode2D.Impulse);
        }
        else if (direction == "left")
        {
            rb.AddForce(new Vector2(-movementSpeed, 0), ForceMode2D.Impulse);
        }

        if (jump)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jump = false;
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
