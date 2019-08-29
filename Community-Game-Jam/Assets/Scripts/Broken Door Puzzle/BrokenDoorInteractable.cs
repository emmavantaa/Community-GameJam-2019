using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenDoorInteractable : MonoBehaviour, IInteractable
{
    public GameObject canvas;
    public Camera mainCamera;
    public Camera brokenDoorCamera;
    public GameObject inventoryPanel;

    public string GetName()
    {
        return name;
    }

    public void Interact()
    {
        print("Interacted");
        mainCamera.gameObject.SetActive(false);
        brokenDoorCamera.gameObject.SetActive(true);
        inventoryPanel.SetActive(false);
        BrokenDoorController.instance.puzzleOpen = true;
        GameManager.instance.player.inPuzzle = true;
    }

    public void PlayerInRange()
    {
        canvas.SetActive(true);
        print("Player in range");
    }

    public void PlayerOutRange()
    {
        canvas.SetActive(false);
        print("Player out of range");
    }
}
