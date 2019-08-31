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
    public List<int> linesToBeRead = new List<int>();
    private int lineIndex = 0;
    public bool lineComplete = true;
    bool allRead = true;

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
        if (allRead == true)
        {
            allRead = false;
            linesToBeRead.Clear();
            linesToBeRead = lineIndexes;
            nextLineIndex = linesToBeRead[0];
            narratorPanel.SetActive(true);
            StartCoroutine(ShowFirstLine()); 
        }
        else
        {
            for (int i = 0; i < lineIndexes.Count; i++)
            {
                linesToBeRead.Add(lineIndexes[i]);
            }
        }
    }

    IEnumerator ShowFirstLine()
    {
        lineComplete = false;
        for (int i = 0; i < lines[nextLineIndex].Length; i++)
        {
            if (lineComplete == false)
            {
                narratorText.text = lines[nextLineIndex].Substring(0, i + 1);
                yield return new WaitForSeconds(delay); 
            }
            else
            {
                break;
            }
        }
        lineComplete = true;
    }

    public IEnumerator NextLine()
    {
        if (lineComplete == true)
        {
            lineComplete = false;
            if (lineIndex < linesToBeRead.Count - 1)
            {
                lineIndex++;
                nextLineIndex = linesToBeRead[lineIndex];
                for (int i = 0; i < lines[nextLineIndex].Length; i++)
                {
                    if (lineComplete == false)
                    {
                        narratorText.text = lines[nextLineIndex].Substring(0, i + 1);
                        yield return new WaitForSeconds(delay); 
                    }
                    else
                    {
                        break;
                    }
                }
                lineComplete = true;
            }
            else
            {
                lineIndex = 0;
                narratorPanel.SetActive(false);
                allRead = true;
            } 
        }
        else
        {
            narratorText.text = lines[nextLineIndex];
            lineComplete = true;
        }
    }
}
