using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using Color = UnityEngine.Color;

public class BacktoMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public TextMeshProUGUI BacktoMenuText;

    public Pausing Paused;

    public void OnPointerEnter(PointerEventData eventData)
    {
        BacktoMenuText.color = new Color(1, 1, 1, 1);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        BacktoMenuText.color = new Color(0.8f, 0.8f, 0.8f, 1);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
        Paused.GamePaused = false;
    }
}

