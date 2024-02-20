using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp : MonoBehaviour
{
    private float MinDistane = 3;

    public Transform Player;

    public Transform KeyItem;

    public Camera Camera;

    public LayerMask Key;

    [HideInInspector] public bool KeyGone;

    public Pausing Paused;
    private float Distance => Vector3.Distance(Player.position, KeyItem.position);

    void Update()
    {
        if (Paused.GamePaused == false)
        {
            Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;

            if (Input.GetMouseButtonDown(0) && Distance <= MinDistane && Physics.Raycast(ray, out Hit, float.MaxValue, Key.value) && KeyGone == false)
            {
                KeyGone = true;
                GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
}
