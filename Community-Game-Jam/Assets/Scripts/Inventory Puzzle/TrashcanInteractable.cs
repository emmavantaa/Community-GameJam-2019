using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashcanInteractable : MonoBehaviour, IInteractable
{
    public GameObject canvas;
    public Item item;
    public KeycardController keycardController;
    public string GetName()
    {
        return name;
    }

    public void Interact()
    {
        if(item != null)
        {
            GameManager.instance.player.Inventory.Add(item);
            KeycardController.instance.UpdateSlots(item);
            item = null;
            NarratorManager.instance.ReadLines(new List<int> { 0, 1 });
        }
        else
        {
            print("can is empty");
        }
    }

    public void PlayerInRange()
    {
        canvas.gameObject.SetActive(true);
    }

    public void PlayerOutRange()
    {
        canvas.gameObject.SetActive(false);
    }
}
