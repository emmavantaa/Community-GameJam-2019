﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightButton : MonoBehaviour
{
    public List<Light> lightsOn = new List<Light>();
    
    public void pressButton()
    {
        for (int i = 0; i < lightsOn.Count; i++)
        {
            lightsOn[i].on = !lightsOn[i].on;
            if(lightsOn[i].on == true)
            {
                lightsOn[i].GetComponent<Renderer>().material = BrokenDoorController.instance.onMaterial;
            }
            else
            {
                lightsOn[i].GetComponent<Renderer>().material = BrokenDoorController.instance.offMaterial;
            }
        }
        BrokenDoorController.instance.checkLights();

    }
}
