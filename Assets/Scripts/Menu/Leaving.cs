using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using Color = UnityEngine.Color;

public class Leaving : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public TextMeshProUGUI ExitText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        ExitText.color = new Color(255, 255, 255, 255);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ExitText.color = new Color(0.8f, 0.8f, 0.8f, 1);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Application.Quit();
    }
}
