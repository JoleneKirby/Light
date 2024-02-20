using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    public Transform Target;

    public float Sensitivity = 5f;

    private float RotationX = 0f;

    public Pausing Paused;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Paused.GamePaused == false)
        {
            float mouseX = Input.GetAxis("Mouse X") * Sensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * Sensitivity;
            RotationX -= mouseY;
            RotationX = Mathf.Clamp(RotationX, -90, 90);
            transform.localRotation = Quaternion.Euler(RotationX, 0, 0);
            Target.Rotate(Vector3.up * mouseX);
        }
    }
}