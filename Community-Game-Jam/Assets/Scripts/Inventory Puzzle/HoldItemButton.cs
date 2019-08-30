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
        if(GameManager.instance.player.heldItem != null)
        {
            Destroy(GameObject.Find("heldItem"));
        }
        GameManager.instance.player.heldItem = GameManager.instance.inspectedItem;
        GameObject heldItem = Instantiate(GameManager.instance.player.heldItem.model, GameManager.instance.player.heldItemPosition);
        heldItem.transform.position = GameManager.instance.player.heldItemPosition.position;
        heldItem.name = "heldItem";
    }
}
