using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    // Start is called before the first frame update
    public float MinDistane = 10f;

    private bool DoorIsOpen = false;

    public Transform Player;

    public Transform TheDoor;

    public Camera Camera;

    public Transform Hinge;

    public LayerMask Door;

    private float Distance => Vector3.Distance(Player.position, TheDoor.position);

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;

        if (Input.GetMouseButtonDown(0) && Distance <= MinDistane && Physics.Raycast(ray, out Hit, float.MaxValue, Door.value) && DoorIsOpen == false)
        {
            DoorIsOpen = true;
            Hinge.transform.Rotate(0, 90, 0);
            Debug.Log(":)");
        }
    }
}
