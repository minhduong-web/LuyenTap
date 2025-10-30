using System.Collections;
using Unity.Mathematics;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    public LayerMask groundLayer;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public float radius = 0.2f;

    private Rigidbody2D rb;
    private bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            StartCoroutine(Jump());
        }
    }

    IEnumerator Jump()
    {
        yield return new WaitForSeconds(0.1f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");

        // Sửa lỗi: dùng rb.velocity thay vì rb.linearVelocity
        rb.linearVelocity = new Vector2(horizontal * moveSpeed, rb.linearVelocity.y);

        // Đảo hướng nhân vật
        if ((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight))
        {
            Flip();
        }
    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, radius, groundLayer);
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    public bool FaceRight()
    {
        return facingRight;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, radius);
    }
}
