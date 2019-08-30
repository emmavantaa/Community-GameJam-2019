using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ComputerController : MonoBehaviour
{
    public static ComputerController instance = null;

    public Camera computerCamera;
    public LayerMask layerMask;
    public Button openDoorButton;
    public Button logOutButton;
    public Button activeButton;
    public bool loggedIn;
    public bool sprinklersOn = false;
    public bool puzzleOpen = false;
    public TMP_InputField passwordInput;
    public GameObject fire;
    public GameObject sprinklers;
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

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            Ray ray = computerCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                if (puzzleOpen == true)
                {
                    GameObject go = hit.transform.gameObject;
                    go.GetComponent<IKeyboardKey>().pressKey(); 
                }
            }
        }
    }
}
