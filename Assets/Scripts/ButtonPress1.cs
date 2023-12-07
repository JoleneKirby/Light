using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress1 : MonoBehaviour
{
    // Start is called before the first frame update
    public float MinDistane = 10f;

    public Transform Player;

    public Transform Button;

    public Camera Camera;

    public LayerMask NotButton;

    private float Distance => Vector3.Distance(Player.position, Button.position);

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;

        if (Input.GetMouseButtonDown(0) && Distance <= MinDistane && Physics.Raycast(ray, out Hit, float.MaxValue, NotButton.value))
        {
            
                {
                    Debug.Log(":D");
                }
        }
    }
}
