using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogOutButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void PressButton()
    {
        ComputerController.instance.puzzleOpen = false;
        GameManager.instance.player.inPuzzle = false;
        GameManager.instance.player.gameObject.SetActive(true);
    }
}
