using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{
    Animator anim;
    public Collider coll;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider>();
    }

    public void OpenDoor()
    {
        anim.SetBool("isOpen", true);
    }
    public void CloseDoor()
    {
        anim.SetBool("isOpen", false);
    }
}
