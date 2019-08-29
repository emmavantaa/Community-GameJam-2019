using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void PressButton()
    {
        GameManager.instance.player.inPuzzle = false;
    }
}
