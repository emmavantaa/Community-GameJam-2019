using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeycardController : MonoBehaviour
{
    public GameObject itemPrefab;
    public List<GameObject> trashCans = new List<GameObject>();
    public List<GameObject> inventorySlots = new List<GameObject>();
    public Sprite emptySprite;
    public Image previewImage;

    public static KeycardController instance = null;

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

    public void UpdateSlots(Item item)
    {
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            if (inventorySlots[i].GetComponent<Image>().sprite == emptySprite)
            {
                inventorySlots[i].GetComponent<Image>().sprite = item.image;
                inventorySlots[i].GetComponent<InventorySlotButton>().itemInSlot = item;
                break;
            }
        }
    }
}
