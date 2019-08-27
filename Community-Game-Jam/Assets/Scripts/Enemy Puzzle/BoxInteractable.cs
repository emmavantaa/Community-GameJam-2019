using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInteractable : MonoBehaviour, IInteractable
{
    public GameObject canvas;
    private Player player;
    GameObject parent;
    public string GetName()
    {
        return name;
    }

    public void Interact()
    {

        if (player.enemySeen == false && player.camouflaged == false)
        {
            Hide();
        }
        else if (player.camouflaged == true)
        {
            UnHide();
        }
    }

    private void UnHide()
    {
        player.camouflaged = false;
        print("visible");
        transform.SetParent(parent.transform);
    }

    private void Hide()
    {
        player.camouflaged = true;
        print("hidden");
        transform.SetParent(player.transform);
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

    private void Start()
    {
        player = GameManager.instance.player;
        parent = transform.parent.gameObject;
    }
}
