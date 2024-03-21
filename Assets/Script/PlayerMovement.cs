using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // ความเร็วของการเคลื่อนที่
    public float jumpForce = 10f; // ความสูงของการกระโดด
    public float groundCheckDistance = 0.2f; // ระยะที่ใช้ตรวจสอบว่าอยู่บนพื้นหรือไม่

    private Rigidbody rb;
    private bool canJump = true; // ตรวจสอบว่าสามารถกระโดดได้หรือไม่
    private bool isJumping = false; // ตรวจสอบว่า OBJ กำลังกระโดดหรือไม่

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // รับอินพุตจากผู้เล่น
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // คำนวณทิศทางของการเคลื่อนที่
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized * speed * Time.deltaTime;

        // เคลื่อนที่ OBJ
        rb.MovePosition(transform.position + transform.TransformDirection(movement));

        // กระทำการกระโดด
        if (canJump && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z); // เซ็ตความเร็วแนวดิ่งเป็น 0 ก่อนกระโดด
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            canJump = false;
            isJumping = true;
        }
    }

    void FixedUpdate()
    {
        // ตรวจสอบว่า OBJ อยู่บนพื้นหรือไม่
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDistance))
        {
            if (!isJumping) // ถ้า OBJ ไม่ได้กำลังกระโดด
            {
                canJump = true;
            }
            isJumping = false;
        }
        else
        {
            canJump = false; // ถ้า OBJ ไม่อยู่บนพื้น ให้ไม่สามารถกระโดดได้
        }
    }
}
