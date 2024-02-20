using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp : MonoBehaviour
{
    private float MinDistance = 3;

    public Transform Player;

    public Camera Camera;

    [HideInInspector] public bool KeyGone;

    public Pausing Paused;
    private float Distance => Vector3.Distance(Player.position, transform.position);

    void Update()
    {
        if (Paused.GamePaused == false)
        {
            Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;

            if (Input.GetMouseButtonDown(0) && Distance <= MinDistance && Physics.Raycast(ray, out Hit, float.MaxValue) && KeyGone == false)
            {
                KeyGone = true;
                GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
}
