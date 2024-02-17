using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigButtonPress : MonoBehaviour
{
    // Start is called before the first frame update
    public float MinDistane = 10f;

    public Transform Player;

    public Transform Button;

    public Camera Camera;

    public LayerMask BigButton;

    public Material ButtonMat;

    public Transform Stutter;

    public ButtonPress1 Button1;

    public ButtonPress2 Button2;

    private bool BigButtonOn = false;

    private float Distance => Vector3.Distance(Player.position, Button.position);

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;

        if (Input.GetMouseButtonDown(0) && Distance <= MinDistane && Physics.Raycast(ray, out Hit, float.MaxValue, BigButton.value) && BigButtonOn == false && Button1.Button1On && Button2.Button2On)
        {
            BigButtonOn = true;
            Button.GetComponent<MeshRenderer>().material = ButtonMat;
            Stutter.transform.position += new Vector3(0, 3, 0);
            Debug.Log("Shutter Door Open :D");
        }   
        else if (Input.GetMouseButtonDown(0) && Distance <= MinDistane && Physics.Raycast(ray, out Hit, float.MaxValue, BigButton.value) && BigButtonOn == false)
        {
            Debug.Log("No Power D:");
        }
    }
}