using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShakeButton : MonoBehaviour
{
    public GameObject inspectPanel;
    public void PressButton()
    {
        Shake();
    }

    void Shake()
    {
        if (GameManager.instance.player.heldItem != null)
        {
            NarratorManager.instance.ReadLines(new List<int> { 17 });
            inspectPanel.SetActive(false);
            GameManager.instance.shaked = true;
            Destroy(GameObject.Find("heldItem"));
            GameManager.instance.player.heldItem = null;
            for (int i = 0; i < KeycardController.instance.inventorySlots.Count; i++)
            {
                if (KeycardController.instance.inventorySlots[i].GetComponent<InventorySlotButton>().itemInSlot != null)
                {
                    if (KeycardController.instance.inventorySlots[i].GetComponent<InventorySlotButton>().itemInSlot.itemName.Contains("Bomb"))
                    {
                        KeycardController.instance.inventorySlots[i].GetComponent<Image>().sprite = KeycardController.instance.emptySprite;
                        KeycardController.instance.inventorySlots[i].GetComponent<InventorySlotButton>().itemInSlot = null;
                        GameManager.instance.player.explosion.Play();
                        break;
                    } 
                }
            }
        }
        else
        {
            NarratorManager.instance.ReadLines(new List<int> { 24 });
        }
    }
}
