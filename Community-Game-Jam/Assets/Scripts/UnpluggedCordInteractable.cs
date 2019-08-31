using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpluggedCordInteractable : MonoBehaviour, IInteractable
{
    public GameObject canvas;
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
    }

    public void PlayerInRange()
    {
        canvas.SetActive(true);
    }

    public void PlayerOutRange()
    {
        canvas.SetActive(false);
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
