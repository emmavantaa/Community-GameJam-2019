using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ComputerController : MonoBehaviour
{
    public Camera computerCamera;
    public LayerMask layerMask;
    public Button openDoorButton;
    public Button logOutButton;
    public Button activeButton;
    public bool loggedIn;
    public bool doorsOpened = false;
    public TMP_InputField passwordInput;
    // Start is called before the first frame update
    void Start()
    {
        
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
                GameObject go = hit.transform.gameObject;
                go.GetComponent<IKeyboardKey>().pressKey();
            }
        }
    }
}
