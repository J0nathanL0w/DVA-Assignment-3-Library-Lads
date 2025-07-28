using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float lookSpeed = 2f;
    public float sprintMultiplier = 2f;
    private float rotationX = 0f;
    private float rotationY = 0f;

    void Update()
    {
        // Camera rotation with mouse
        rotationX += Input.GetAxis("Mouse X") * lookSpeed;
        rotationY -= Input.GetAxis("Mouse Y") * lookSpeed;
        rotationY = Mathf.Clamp(rotationY, -90f, 90f); // prevent flipping
        transform.localRotation = Quaternion.Euler(rotationY, rotationX, 0f);
    }
}
