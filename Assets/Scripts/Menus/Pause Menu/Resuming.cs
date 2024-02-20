using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using Color = UnityEngine.Color;

public class Resuming : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public TextMeshProUGUI ResumeText;

    public Pausing Paused;

    public void OnPointerEnter(PointerEventData eventData)
    {
        ResumeText.color = new Color(1, 1, 1, 1);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ResumeText.color = new Color(0.8f, 0.8f, 0.8f, 1);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Paused.PauseMenu.SetActive(false);
        Paused.Crosshair.SetActive(true);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Paused.GamePaused = false;
    }
}
