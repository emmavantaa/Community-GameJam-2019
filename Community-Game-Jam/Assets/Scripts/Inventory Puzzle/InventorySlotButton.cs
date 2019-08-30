using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotButton : MonoBehaviour
{
    public GameObject inspectPanel;
    public Item itemInSlot;
    public void PressButton()
    {
        inspectPanel.SetActive(true);
        KeycardController.instance.previewImage.sprite = itemInSlot.image;
        GameManager.instance.inspectedItem = itemInSlot;
    }
}
