using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // ตำแหน่งที่กล้องจะตาม
    
        public float rotationSpeed = 5f; // ความเร็วในการหมุนกล้อง
    
        void LateUpdate()
        {
            if (target != null)
            {
                // คำนวณตำแหน่งที่ต้องการให้กล้องอยู่
                transform.position = target.position;
    
                // หมุนกล้องซ้ายขวาเมื่อกดปุ่ม Q หรือ E
                if (Input.GetKey(KeyCode.Q))
                {
                    transform.RotateAround(target.position, Vector3.up, -rotationSpeed * Time.deltaTime);
                }
                else if (Input.GetKey(KeyCode.E))
                {
                    transform.RotateAround(target.position, Vector3.up, rotationSpeed * Time.deltaTime);
                }
            }
        }
}
