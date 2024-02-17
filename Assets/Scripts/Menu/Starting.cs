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

public class Exiting : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public TextMeshProUGUI StartText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        StartText.color = new Color(255, 255, 255, 255);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StartText.color = new Color(0.8f, 0.8f, 0.8f, 1);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene("Game World");
    }
}
