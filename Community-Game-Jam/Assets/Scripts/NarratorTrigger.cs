using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarratorTrigger : MonoBehaviour
{
    private bool triggered = false;
    public List<int> linesToRead = new List<int>();

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && triggered == false)
        {
            NarratorManager.instance.ReadLines(linesToRead);
            triggered = true;
        } 
    }
}
