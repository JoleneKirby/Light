using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoorOpen : MonoBehaviour
{
    private float MinDistance = 3;

    [HideInInspector] public bool DoorIsOpen;

    public Transform Player;

    public Transform TheDoor;

    public Camera Camera;

    public Transform Hinge;

    public LayerMask LockedDoor;

    public KeyPickUp Key;

    [HideInInspector] public bool IsLocked;

    private bool RightAngle;

    private float Counter = 180;

    public Pausing Paused;

    public float Distance => Vector3.Distance(Player.position, TheDoor.position);

    void Update()
    {
        if (Paused.GamePaused == false)
        {
            Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;

            IsLocked = false;

            if (Input.GetMouseButtonDown(0) && Distance <= MinDistance && Physics.Raycast(ray, out Hit, float.MaxValue, LockedDoor.value) && DoorIsOpen == false && Key.KeyGone)
            {
                DoorIsOpen = true;
            }
            else if (Input.GetMouseButtonDown(0) && Distance <= MinDistance && Physics.Raycast(ray, out Hit, float.MaxValue, LockedDoor.value) && DoorIsOpen == false)
            {
                IsLocked = true;
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
