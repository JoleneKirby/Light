using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    private float MinDistance = 3;

    private bool DoorIsOpen;

    public Transform Player;

    public Transform TheDoor;

    public Camera Camera;

    public Transform Hinge;

    public LayerMask Door;

    public Pausing Paused;

    private bool RightAngle;

    private float Counter = 180;

    private float Distance => Vector3.Distance(Player.position, TheDoor.position);

    void Update()
    {
        if (Paused.GamePaused == false)
        {
            Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;

            if (Input.GetMouseButtonDown(0) && Distance <= MinDistance && Physics.Raycast(ray, out Hit, float.MaxValue, Door.value) && DoorIsOpen == false)
            {
                DoorIsOpen = true;
            }

            if (DoorIsOpen == true && RightAngle == false)
            {
                Hinge.transform.Rotate(0, 0.5f, 0);
                Counter -= 1;

                if (Counter <= 0)
                {
                    RightAngle = true;
                }
            }
        }
    }
}
