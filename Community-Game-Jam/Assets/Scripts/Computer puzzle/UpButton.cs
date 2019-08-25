using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpButton : MonoBehaviour, IKeyboardKey
{
    public ComputerController computerController;

    public void pressKey()
    {
        computerController.activeButton = computerController.openDoorButton;
        computerController.activeButton.GetComponent<Image>().color = Color.blue;
        computerController.logOutButton.GetComponent<Image>().color = Color.white;
    }
}
