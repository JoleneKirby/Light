using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legs : MonoBehaviour
{
    public CharacterController Controller;

    public float Speed = 5f;

    public float Gravity = 10f;

    Vector3 Velocity;

    void Start()
    {

    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        Controller.Move(move * Speed * Time.deltaTime);

        Velocity.y -= Gravity * Time.deltaTime;

        Controller.Move(Velocity);

        if (Input.GetKey("left shift"))
        {
            Speed = 2f;
            transform.localScale = new Vector3(1f, 0.5f, 1f);
        }         
        else
        {
            Speed = 5f;
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            Speed = 10f;
        }
        else
        {
            Speed = 5f;
        }
    }
}