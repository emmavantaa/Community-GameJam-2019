using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnSprinklersButton : MonoBehaviour, IKeyboardKey
{
    public ComputerController cc;
    public void pressKey()
    {
        if (!cc.sprinklersOn)
        {
            print("Sprinklers on");
            cc.sprinklersOn = true;
            cc.fire.SetActive(false);
            cc.sprinklers.SetActive(true);
        }
        else
        {
            print("Sprinklers already on");
        }
    }
}
