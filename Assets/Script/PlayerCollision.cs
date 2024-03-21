using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Vector3 startPosition;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position; // เก็บตำแหน่งเริ่มต้น
    }

    // เมื่อ Player ชนกับ Collider อื่น ๆ
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")) // สมมติว่าเก็บ Player ชนกับ Obstacle
        {
            ResetPlayerPosition(); // เรียกใช้ฟังก์ชันเพื่อให้ Player กลับไปยังตำแหน่งเริ่มต้น
        }
    }

    // ฟังก์ชันเพื่อให้ Player กลับไปยังตำแหน่งเริ่มต้น
    void ResetPlayerPosition()
    {
        rb.velocity = Vector3.zero; // หยุดความเร็วของ Player
        rb.angularVelocity = Vector3.zero; // หยุดการหมุนของ Player
        transform.position = startPosition; // กลับไปยังตำแหน่งเริ่มต้น
    }
}
