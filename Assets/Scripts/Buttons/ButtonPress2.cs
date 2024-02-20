using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress2 : MonoBehaviour
{
    private float MinDistance = 3;

    public Transform Player;

    public Camera Camera;

    public LayerMask Button2;

    public Material ButtonMat;

    [HideInInspector] public bool Button2On;

    public Pausing Paused;

    private float Distance => Vector3.Distance(Player.position, transform.position);

    void Update()
    {
        if (Paused.GamePaused == false)
        {
            Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;

            if (Input.GetMouseButtonDown(0) && Distance <= MinDistance && Physics.Raycast(ray, out Hit, float.MaxValue, Button2.value) && Button2On == false)
            {
                Button2On = true;
                GetComponent<MeshRenderer>().material = ButtonMat;
            }
        }
    }
}
