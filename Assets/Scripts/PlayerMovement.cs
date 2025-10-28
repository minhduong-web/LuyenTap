using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Cấu hình di chuyển")]
    public float moveSpeed = 5f; // tốc độ di chuyển

    private Rigidbody2D rb;
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Nhận input: A = -1, D = +1
        moveInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        // Di chuyển theo trục X (trái/phải)
        rb.MovePosition(rb.position + new Vector2(moveInput * moveSpeed * Time.fixedDeltaTime, 0f));
    }
}
