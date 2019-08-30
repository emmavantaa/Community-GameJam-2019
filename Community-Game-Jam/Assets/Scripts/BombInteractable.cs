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
        GameManager.instance.player.Inventory.Add(item);
        KeycardController.instance.UpdateSlots(item);
    }

    public void PlayerInRange()
    {
        canvas.SetActive(true);
    }

    public void PlayerOutRange()
    {
        canvas.SetActive(false);
    }
}
