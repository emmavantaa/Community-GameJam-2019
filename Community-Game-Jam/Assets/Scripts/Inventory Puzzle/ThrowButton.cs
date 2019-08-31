using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowButton : MonoBehaviour
{
    public GameObject inspectPanel;
    public GameObject mainDeckDoor;
    public float distance;
    public void PressButton()
    {
        Throw();
    }

    void Throw()
    {
        float distanceToDoor = Vector3.Distance(mainDeckDoor.transform.position, GameManager.instance.player.transform.position);
        if (GameManager.instance.player.heldItem != null)
        {
            if (distanceToDoor < distance + 5 && distanceToDoor > distance - 5)
            {
                inspectPanel.SetActive(false);
                Destroy(GameObject.Find("heldItem"));
                GameManager.instance.player.heldItem = null;
                GameManager.instance.mainDeckDoorOpen = true;
                NarratorManager.instance.ReadLines(new List<int> { 26 });
                for (int i = 0; i < KeycardController.instance.inventorySlots.Count; i++)
                {
                    if (KeycardController.instance.inventorySlots[i].GetComponent<InventorySlotButton>().itemInSlot != null)
                    {
                        if (KeycardController.instance.inventorySlots[i].GetComponent<InventorySlotButton>().itemInSlot.itemName.Contains("Bomb"))
                        {
                            KeycardController.instance.inventorySlots[i].GetComponent<Image>().sprite = KeycardController.instance.emptySprite;
                            KeycardController.instance.inventorySlots[i].GetComponent<InventorySlotButton>().itemInSlot = null;
                            GameManager.instance.mainDeckDoor.GetComponent<Open>().OpenDoor();
                            break;
                        }
                    }
                }
            }
            else if (distanceToDoor > distance + 5)
            {
                NarratorManager.instance.ReadLines(new List<int> { 28 });
            }
            else if (distanceToDoor < distance - 5)
            {
                NarratorManager.instance.ReadLines(new List<int> { 27 });
            }
        }
        else
        {
            NarratorManager.instance.ReadLines(new List<int> { 25 });
        }
        
    }
}
