using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legs : MonoBehaviour
{
    public CharacterController Controller;

    private float Speed = 5;

    Vector3 Velocity;

    public Pausing Paused;

    private bool UnderCelling;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        RaycastHit Hit; 
        Vector3 move = transform.right * x + transform.forward * z;
        Controller.Move(move * Speed * Time.deltaTime);
        Velocity.y -= Time.deltaTime;
        Controller.Move(Velocity);

        if (Paused.GamePaused == false)
        {
            if (Input.GetKey("left shift"))
            {
                Speed = 2;
                transform.localScale = new Vector3(1, 0.5f, 1);
            }
            else
            {
                if (Input.GetKeyUp("left shift") && Physics.Raycast(transform.position, Vector3.up, out Hit, 2))
                {
                    UnderCelling = true;
                }

                if (UnderCelling == true && Physics.Raycast(transform.position, Vector3.up, out Hit, 2))
                {
                    Speed = 2;
                    transform.localScale = new Vector3(1, 0.5f, 1);
                }
                else
                {
                    UnderCelling = false;
                    Speed = 5;
                    transform.localScale = new Vector3(1, 1, 1);

                    if (Input.GetKey(KeyCode.LeftControl))
                    {
                        Speed = 10;
                    }
                }
            }
        }
    }
}