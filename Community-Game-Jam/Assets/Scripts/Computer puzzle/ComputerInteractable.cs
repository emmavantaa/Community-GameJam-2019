using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerInteractable : MonoBehaviour, IInteractable
{
    public GameObject canvas;
    public Camera mainCamera;
    public Camera computerCamera;
    public GameObject inventoryPanel;
    public void PlayerInRange()
    {
        canvas.SetActive(true);
        print("Player in range");
    }

    public void Interact()
    {
        print("Interacted");
        mainCamera.gameObject.SetActive(false);
        computerCamera.gameObject.SetActive(true);
        ComputerController.instance.puzzleOpen = true;
        inventoryPanel.SetActive(false);
        GameManager.instance.player.inPuzzle = true;
        GameManager.instance.player.gameObject.SetActive(false);
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
