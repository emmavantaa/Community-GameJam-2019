using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterButton : MonoBehaviour, IKeyboardKey
{
    public ComputerController computerController;
    public void pressKey()
    {
        GetComponent<AudioSource>().Play();
        computerController.activeButton.onClick.Invoke();
    }
}
