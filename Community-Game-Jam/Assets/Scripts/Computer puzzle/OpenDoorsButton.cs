using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorsButton : MonoBehaviour, IKeyboardKey
{
    public ComputerController cc;
    public void pressKey()
    {
        if (!cc.doorsOpened)
        {
            print("Doors opened");
            cc.doorsOpened = true;
        }
        else
        {
            print("Doors already open");
        }
    }
}
