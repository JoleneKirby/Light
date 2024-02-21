using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Winning : MonoBehaviour    
{
    public GameObject PauseCube;

    public GameObject Crosshair;

    public TextMeshProUGUI WinnerText;

    public Rigidbody Player;

    private IEnumerator OnTriggerEnter(Collider other)
    {
        Destroy(Player);
        PauseCube.SetActive(false);
        Crosshair.SetActive(false);
        WinnerText.color = new Color(0.75f, 1, 0, 1);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Main Menu");
        Cursor.lockState = CursorLockMode.None;
    }
}
