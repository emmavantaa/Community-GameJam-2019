using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenDoorController : MonoBehaviour
{
    public static BrokenDoorController instance = null;
    public Material onMaterial;
    public Material offMaterial;
    public bool puzzleOpen = false;
    public Camera doorCamera;
    public LayerMask layerMask;
    public List<Light> lights = new List<Light>();
    public bool allOn = false;

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            Ray ray = doorCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                if (puzzleOpen == true)
                {
                    GameObject go = hit.transform.gameObject;
                    go.GetComponent<LightButton>().pressButton();
                }
            }
        }

    }

    public void checkLights()
    {
        int count = 0;
        for (int i = 0; i < lights.Count; i++)
        {
            if(lights[i].on == true)
            {
                count++;
            }
        }
        if(count == lights.Count)
        {
            allOn = true;
            print("COMPLETED!");
        }
    }
}
