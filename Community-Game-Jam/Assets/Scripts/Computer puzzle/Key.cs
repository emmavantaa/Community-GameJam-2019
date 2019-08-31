using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Key : MonoBehaviour, IKeyboardKey
{
    public ComputerController computerController;
    public char key;
    // Start is called before the first frame update
    public void pressKey()
    {
        computerController.passwordInput.text += key;
        print(computerController.passwordInput.text);
        GetComponent<AudioSource>().Play();
    }
}
