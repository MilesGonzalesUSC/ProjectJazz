using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 15, 0); // 每秒旋转的角速度 (度/秒)

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
