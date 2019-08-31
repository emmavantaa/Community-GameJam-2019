using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpluggedCordInteractable : MonoBehaviour, IInteractable
{
    public GameObject canvas;
    public GameObject sparks;
    public string GetName()
    {
        return name;
    }

    public void Interact()
    {
        GameManager.instance.cordPlugged = true;
        NarratorManager.instance.ReadLines(new List<int> { 4,5,6 });
        gameObject.SetActive(false);
        GameManager.instance.startDoor.GetComponent<Open>().CloseDoor();
        GameManager.instance.flashLight.SetActive(false);
        GameManager.instance.lightning.SetActive(true);
        sparks.SetActive(false);
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
