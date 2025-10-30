using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [Header("Fire Settings")]
    public float bulletSpeed = 10f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    private PlayerController playerController;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            // Kiểm tra hướng quay của nhân vật
            if (playerController != null && playerController.FaceRight())
            {
                // Quay phải → bắn sang phải
                rb.linearVelocity = Vector2.right * bulletSpeed;
                bullet.transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                // Quay trái → bắn sang trái
                rb.linearVelocity = Vector2.left * bulletSpeed;
                bullet.transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }
}
