using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameObject endPanel;
    private void OnTriggerEnter(Collider other)
    {
        if(GameManager.instance.mainDeckDoorOpen == true)
        {
            endPanel.SetActive(true);
        }
    }
}
