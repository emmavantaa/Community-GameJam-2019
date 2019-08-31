using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerInteractable : MonoBehaviour, IInteractable
{
    public GameObject canvas;
    public Camera mainCamera;
    public Camera computerCamera;
    public GameObject inventoryPanel;
    bool used = false;
    public void PlayerInRange()
    {
        if (GameManager.instance.storageDoorOpen == true)
        {
            canvas.SetActive(true);
            print("Player in range"); 
        }
    }

    public void Interact()
    {
        if (GameManager.instance.storageDoorOpen == true)
        {
            print("Interacted");
            mainCamera.gameObject.SetActive(false);
            computerCamera.gameObject.SetActive(true);
            ComputerController.instance.puzzleOpen = true;
            inventoryPanel.SetActive(false);
            GameManager.instance.player.inPuzzle = true;
            GameManager.instance.player.gameObject.SetActive(false);
            if(used == false)
            {
                NarratorManager.instance.ReadLines(new List<int> { 14 });
                used = true;
            }
        }
    }
    public void PlayerOutRange()
    {
        canvas.SetActive(false);
        print("Player out of range");
    }

    public string GetName()
    {
        return name;
    }

}
