using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NarratorManager : MonoBehaviour
{
    public static NarratorManager instance = null;
    public GameObject narratorPanel;
    public TMP_Text narratorText;
    public float delay = 0.05f;
    public List<string> lines = new List<string>();
    public int nextLineIndex;
    [HideInInspector]
    public List<int> linesToRead = new List<int>();
    private int lineIndex = 0;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ReadLines(List<int> lineIndexes)
    {
        linesToRead.Clear();
        linesToRead = lineIndexes;
        nextLineIndex = linesToRead[0];
        narratorPanel.SetActive(true);
        StartCoroutine(ShowFirstLine());
    }

    IEnumerator ShowFirstLine()
    {
        for (int i = 0; i < lines[nextLineIndex].Length; i++)
        {
            narratorText.text = lines[nextLineIndex].Substring(0, i+1);
            yield return new WaitForSeconds(delay);
        }
    }

    public IEnumerator NextLine()
    {
        if(lineIndex < linesToRead.Count - 1)
        {
            lineIndex++;
            nextLineIndex = linesToRead[lineIndex];
            for (int i = 0; i < lines[nextLineIndex].Length; i++)
            {
                narratorText.text = lines[nextLineIndex].Substring(0, i+1);
                yield return new WaitForSeconds(delay);
            }
        }
        else
        {
            lineIndex = 0;
            narratorPanel.SetActive(false);
        }
    }
}
