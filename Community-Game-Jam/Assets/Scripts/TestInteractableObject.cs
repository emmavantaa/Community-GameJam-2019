using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestInteractableObject : MonoBehaviour, IInteractable
{
    public GameObject canvas;
    public void PlayerInRange()
    {
        canvas.SetActive(true);
        print("Player in range");
    }

    public void Interact()
    {
        print("Interacted");
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
