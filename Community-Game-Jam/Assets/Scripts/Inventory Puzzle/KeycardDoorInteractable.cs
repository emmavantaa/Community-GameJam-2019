using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeycardDoorInteractable : MonoBehaviour, IInteractable
{
    public GameObject canvas;
    public Item keycard;
    public string GetName()
    {
        return name;
    }

    public void Interact()
    {
        print("Interacted");
        if(GameManager.instance.player.heldItem == keycard)
        {
            print("Door Opened");
            GameManager.instance.storageDoorOpen = true;
            GameManager.instance.warehouseDoor.GetComponent<Open>().OpenDoor();
        }
        else if(GameManager.instance.player.heldItem == null)
        {
            NarratorManager.instance.ReadLines(new List<int> { 31 });
        }
        else
        {
            print("Wrong keycard");
        }
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
