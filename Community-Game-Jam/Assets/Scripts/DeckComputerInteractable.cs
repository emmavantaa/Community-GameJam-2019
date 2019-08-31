using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckComputerInteractable : MonoBehaviour, IInteractable
{
    public GameObject canvas;
    public string GetName()
    {
        return name;
    }

    public void Interact()
    {
        if(GameManager.instance.exitDoorOpen == false)
        {
            GameManager.instance.exitDoorOpen = true;
            print("Exit door opened");
            GameManager.instance.startDoor.GetComponent<Open>().OpenDoor();
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
