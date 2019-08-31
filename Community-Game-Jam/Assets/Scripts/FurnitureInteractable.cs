using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureInteractable : MonoBehaviour, IInteractable
{
    Animator anim;
    bool open = false;
    public GameObject canvas;
    public string GetName()
    {
        throw new System.NotImplementedException();
    }

    public void Interact()
    {
        open = !open;
        anim.SetBool("isOpen", true);
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
        anim = GetComponent<Animator>();
    }
}
