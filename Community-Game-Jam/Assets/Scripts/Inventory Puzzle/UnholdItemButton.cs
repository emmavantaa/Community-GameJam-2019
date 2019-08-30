using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnholdItemButton : MonoBehaviour
{
    public void PressButton()
    {
        UnholdItem();
    }

    private void UnholdItem()
    {
        GameManager.instance.player.heldItem = null;
    }
}
