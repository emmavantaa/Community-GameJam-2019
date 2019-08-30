using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldItemButton : MonoBehaviour
{
    
    public void PressButton()
    {
        HoldItem();
    }
    private void HoldItem()
    {
        GameManager.instance.player.heldItem = GameManager.instance.inspectedItem;
    }
}
