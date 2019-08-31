using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInteractable : MonoBehaviour, IInteractable
{
    public GameObject canvas;
    private Player player;
    public string GetName()
    {
        return name;
    }

    public void Interact()
    {

        if (GameManager.instance.mainDeckDoorOpen == true)
        {
            if (player.enemySeen == false && player.camouflaged == false)
            {
                player.camouflaged = true;
                player.Hide();
                Destroy(gameObject);
                if (GameManager.instance.firstTimeInBox == false)
                {
                    NarratorManager.instance.ReadLines(new List<int> { 20 });
                    GameManager.instance.firstTimeInBox = true;
                }
            } 
        }
    }

    

    public void PlayerInRange()
    {
        if (GameManager.instance.mainDeckDoorOpen == true)
        {
            canvas.SetActive(true);
            print("Player in range"); 
        }
    }

    public void PlayerOutRange()
    {
        if (player.hasBox == false)
        {
            canvas.SetActive(false);
            print("Player out of range"); 
        }
    }

    private void Start()
    {
        player = GameManager.instance.player;
    }
}
