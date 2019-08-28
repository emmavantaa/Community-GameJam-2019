using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLineButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void PressButton()
    {
        StartCoroutine(NarratorManager.instance.NextLine());
    }
}
