using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress1 : MonoBehaviour
{
    private float MinDistane = 3;

    public Transform Player;

    public Transform Button;

    public Camera Camera;

    public LayerMask Button1;

    public Material ButtonMat;

    [HideInInspector] public bool Button1On;

    public Pausing Paused;

    private float Distance => Vector3.Distance(Player.position, Button.position);

    void Update()
    {
        if (Paused.GamePaused == false)
        {
            Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;

            if (Input.GetMouseButtonDown(0) && Distance <= MinDistane && Physics.Raycast(ray, out Hit, float.MaxValue, Button1.value) && Button1On == false)
            {
                Button1On = true;
                Button.GetComponent<MeshRenderer>().material = ButtonMat;
            }
        }
    }
}
