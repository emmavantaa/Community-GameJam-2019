using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotButton : MonoBehaviour
{
    public GameObject inspectPanel;
    public Item itemInSlot;
    public GameObject throwButton;
    public GameObject shakeButton;
    public void PressButton()
    {
        if (itemInSlot != null)
        {
            inspectPanel.SetActive(true);

            KeycardController.instance.previewImage.sprite = itemInSlot.image;
            GameManager.instance.inspectedItem = itemInSlot;

            if (itemInSlot.itemName.Contains("Bomb"))
            {
                if (GameManager.instance.shaked == true)
                {
                    throwButton.SetActive(true);
                }
                shakeButton.SetActive(true);
            }
            else
            {
                throwButton.SetActive(false);
                shakeButton.SetActive(false);
            }
        }
    }
}
