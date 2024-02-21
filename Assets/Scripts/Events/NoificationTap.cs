using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class NoificationTap : MonoBehaviour
{
    public GameObject[] NotificationText;

    public ButtonPress1 Button1;
    
    public ButtonPress2 Button2;
    
    public BigButtonPress BigButton;
    
    public LockedDoorOpen LockedDoor;
    
    public KeyPickUp Key;

    public bool[] TextUp;

    void Start()
    {
        foreach (var item in NotificationText)
        {
            item.SetActive(false);
        }

        for (int i = 0; i < TextUp.Length; i++)
        {
            TextUp[i] = false;
        }

        StartCoroutine("ShowText");
    }

    private IEnumerator ShowText()
    {
        void SaltTheEarth()
        {
            foreach (var item in NotificationText)
            {
                item.SetActive(false);
            }
        }
        
        while (true)
        {
            if (Button1.Button1On == true && TextUp[0] == false || Button2.Button2On == true && TextUp[1] == false)
            {
                if (Button1.Button1On == true && Button2.Button2On == true)
                {
                    if (TextUp[0] == false)
                    {
                        SaltTheEarth();
                        TextUp[0] = true;
                        TextUp[1] = true;
                        NotificationText[2].SetActive(true);
                        NotificationText[0].SetActive(true);
                        yield return new WaitForSeconds(1);
                        NotificationText[2].SetActive(false);
                        NotificationText[0].SetActive(false);
                    }
                    else
                    {
                        SaltTheEarth();
                        TextUp[0] = true;
                        TextUp[1] = true;
                        NotificationText[2].SetActive(true);
                        NotificationText[1].SetActive(true);
                        yield return new WaitForSeconds(1);
                        NotificationText[2].SetActive(false);
                        NotificationText[1].SetActive(false);
                    }
                }
                else if (Button2.Button2On == true)
                {
                    SaltTheEarth();
                    TextUp[1] = true;
                    NotificationText[1].SetActive(true);
                    yield return new WaitForSeconds(1);
                    NotificationText[1].SetActive(false);
                }
                else
                {
                    SaltTheEarth();
                    TextUp[0] = true;
                    NotificationText[0].SetActive(true);
                    yield return new WaitForSeconds(1);
                    NotificationText[0].SetActive(false);
                }
            }

            if (BigButton.PowerOff == true)
            {
                SaltTheEarth();
                NotificationText[3].SetActive(true);
                yield return new WaitForSeconds(1);
                NotificationText[3].SetActive(false);
            }
            else if (BigButton.BigButtonOn == true && TextUp[2] == false)
            {
                SaltTheEarth();
                TextUp[2] = true;
                NotificationText[4].SetActive(true);
                yield return new WaitForSeconds(1);
                NotificationText[4].SetActive(false);
            }

            if (LockedDoor.IsLocked == true)
            {
                SaltTheEarth();
                NotificationText[5].SetActive(true);
                yield return new WaitForSeconds(1);
                NotificationText[5].SetActive(false);
            }
            else if (LockedDoor.DoorIsOpen == true && TextUp[3] == false)
            {
                SaltTheEarth();
                TextUp[3] = true;
                NotificationText[6].SetActive(true);
                yield return new WaitForSeconds(1);
                NotificationText[6].SetActive(false);
            }

            if (Key.KeyGone == true && TextUp[4] == false)
            {
                SaltTheEarth();
                TextUp[4] = true;
                NotificationText[7].SetActive(true);
                yield return new WaitForSeconds(1);
                NotificationText[7].SetActive(false);
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
