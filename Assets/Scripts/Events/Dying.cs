using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dying : MonoBehaviour
{
    public GameObject DeathScreen;

    void Start()
    {
        DeathScreen.SetActive(false);
    }

    private IEnumerator OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Creature"))
        {
            DeathScreen.SetActive(true);
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene("Game World");
        }
    }
}
