using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashcanInteractable : MonoBehaviour, IInteractable
{
    public GameObject canvas;
    public Item item;
    public KeycardController keycardController;
    Animator anim;
    public string GetName()
    {
        return name;
    }

    public void Interact()
    {
        NarratorManager.instance.ReadLines(new List<int> { 30 });
        if (item != null)
        {
            GameManager.instance.player.Inventory.Add(item);
            KeycardController.instance.UpdateSlots(item);
            item = null;
        }
        else
        {
            print("can is empty");
        }
        anim.SetBool("isOpen", true);
    }

    public void PlayerInRange()
    {
        canvas.gameObject.SetActive(true);
    }

    public void PlayerOutRange()
    {
        canvas.gameObject.SetActive(false);
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
}
