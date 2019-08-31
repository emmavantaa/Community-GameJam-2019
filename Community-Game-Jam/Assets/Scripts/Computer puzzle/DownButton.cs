using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DownButton : MonoBehaviour, IKeyboardKey
{
    public ComputerController computerController;
    public void pressKey()
    {
        GetComponent<AudioSource>().Play();
        if (computerController.loggedIn == true)
        {
            computerController.activeButton = computerController.logOutButton;
            computerController.activeButton.GetComponent<Image>().color = Color.blue;
            computerController.openDoorButton.GetComponent<Image>().color = Color.white; 
        }
    }
}
