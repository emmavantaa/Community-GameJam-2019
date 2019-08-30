using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginButton : MonoBehaviour, IKeyboardKey
{
    public ComputerController computerController;
    public GameObject mainPanel;
    public GameObject loginPanel;
    public void pressKey()
    {
        if(computerController.loggedIn == false && computerController.passwordInput.text == "AAA")
        {
            computerController.loggedIn = true;
            computerController.activeButton = computerController.openDoorButton;
            computerController.activeButton.GetComponent<Image>().color = Color.blue;
            loginPanel.gameObject.SetActive(false);
            mainPanel.gameObject.SetActive(true);
        }
        else
        {
            computerController.passwordInput.text = "";
            print("Wrong pass");
        }
    }
}
