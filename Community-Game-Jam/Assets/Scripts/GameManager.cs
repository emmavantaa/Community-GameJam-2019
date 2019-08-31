using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public Player player;
    public Transform enemyRespawn;
    public Item inspectedItem;
    public bool cordPlugged = false;
    public bool storageDoorOpen = false;
    public bool mainDeckDoorOpen = false;
    public bool exitDoorOpen = false;
    public bool enemyHit = false;
    public bool firstTimeInBox = false;
    public bool shaked = false;

    public GameObject startDoor;
    public GameObject hallDoor;
    public GameObject mainDeckDoor;
    public GameObject quartersDoor;
    public GameObject warehouseDoor;

    public GameObject lightning;
    public GameObject flashLight;
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
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        lightning.SetActive(false);
        flashLight.SetActive(true);
        
    }
}
