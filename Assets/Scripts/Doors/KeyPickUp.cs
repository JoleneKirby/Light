using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp : MonoBehaviour
{
    // Start is called before the first frame update
    public float MinDistane = 10f;

    public Transform Player;

    public Transform KeyItem;

    public Camera Camera;

    public LayerMask Key;

    public bool KeyGone = false;

    private float Distance => Vector3.Distance(Player.position, KeyItem.position);

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;

        if (Input.GetMouseButtonDown(0) && Distance <= MinDistane && Physics.Raycast(ray, out Hit, float.MaxValue, Key.value) && KeyGone == false)
        {
            KeyGone = true;
            Debug.Log("You Got a Key :D");
            GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
