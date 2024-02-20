using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigButtonPress : MonoBehaviour
{
    private float MinDistance = 3;

    public Transform Player;

    public Transform Button;

    public Camera Camera;

    public LayerMask BigButton;

    public Material ButtonMat;

    public Transform Stutter;

    public ButtonPress1 Button1;

    public ButtonPress2 Button2;

    public Pausing Paused;

    private bool RightHeight = false;

    private float Counter = 350;

    [HideInInspector] public bool BigButtonOn;
    
    [HideInInspector] public bool PowerOff;

    public float Distance => Vector3.Distance(Player.position, Button.position);

    void Update()
    {
        if (Paused.GamePaused == false)
        {
            Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;
            PowerOff = false;

            if (Input.GetMouseButtonDown(0) && Distance <= MinDistance && Physics.Raycast(ray, out Hit, float.MaxValue, BigButton.value) && BigButtonOn == false && Button1.Button1On == true && Button2.Button2On == true)
            {
                BigButtonOn = true;
                Button.GetComponent<MeshRenderer>().material = ButtonMat;
            }
            else if (Input.GetMouseButtonDown(0) && Distance <= MinDistance && Physics.Raycast(ray, out Hit, float.MaxValue, BigButton.value) && BigButtonOn == false)
            {
                PowerOff = true;
            }

            if (BigButtonOn == true && RightHeight == false)
            {
                Stutter.transform.Translate(0, 0.01f, 0);
                Counter -= 1;

                if (Counter <= 0)
                {
                    RightHeight = true;
                }
            }
        }
    }
}