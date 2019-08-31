using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombInteractable : MonoBehaviour, IInteractable
{
    public Item item;
    public GameObject canvas;
    public string GetName()
    {
        return name;
    }

    public void Interact()
    {
        if (GameManager.instance.mainDeckDoorOpen == false)
        {
            bool found = false;
            for (int i = 0; i < KeycardController.instance.inventorySlots.Count; i++)
            {
                if (KeycardController.instance.inventorySlots[i].GetComponent<InventorySlotButton>().itemInSlot == item)
                {
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                GameManager.instance.player.Inventory.Add(item);
                KeycardController.instance.UpdateSlots(item);
                NarratorManager.instance.ReadLines(new List<int> { 15, 16 });
            }
            else
            {
                print("Bomb already in inventory");
                NarratorManager.instance.ReadLines(new List<int> { 23 });
            } 
        }
    }

    public void PlayerInRange()
    {
        if (GameManager.instance.mainDeckDoorOpen == false)
        {
            canvas.SetActive(true); 
        }
    }

    public void PlayerOutRange()
    {
        canvas.SetActive(false);
    }
}
