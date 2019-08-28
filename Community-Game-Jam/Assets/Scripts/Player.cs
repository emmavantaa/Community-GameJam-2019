using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed = 1;
    public float interactRadius;
    public LayerMask layerMask;
    public IInteractable interactable;
    private Rigidbody rb;
    public List<Item> Inventory = new List<Item>();
    public float rotDampening = 20;
    public bool camouflaged;
    public bool enemySeen;
    private bool buttonDown;
    public GameObject playerModel;
    public float yawRot = 18;
    float desiredYaw = 0;
    float desiredRot = 0;
    int divider = 0;

    private bool interactableInRadius = false; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    #region Movement
    {
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            desiredYaw = 0;
            buttonDown = false;
        }
        if (buttonDown == true)
        {
            desiredYaw = 0;
            desiredRot = 0;
            divider = 0; 
        }
        bool wActive = false;
        #region regular controls
        /*if (Input.GetKey(KeyCode.W)) {
            transform.position += new Vector3(1 * Time.deltaTime * speed, 0, 0);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(-1 * Time.deltaTime * speed, 0, 0);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(0, 0, 1 * Time.deltaTime * speed);
            transform.eulerAngles = new Vector3(0, -90, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0, 0, -1 * Time.deltaTime * speed);
            transform.eulerAngles = new Vector3(0, 90, 0);
        }*/
        #endregion
        #region space controls
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(new Vector3(Time.deltaTime * speed,0,0));
            desiredRot += 0;
            divider++;
            desiredYaw = yawRot;
            wActive = true;
            buttonDown = true;
}
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(new Vector3(-Time.deltaTime * speed, 0, 0));
            desiredRot += 180;
            divider++;
            desiredYaw = yawRot;
            buttonDown = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector3(0, 0, Time.deltaTime * speed));
            if (wActive == false)
            {
                desiredRot += 270; 
            }
            else
            {
                desiredRot += -90;
            }
            divider++;
            desiredYaw = yawRot;
            buttonDown = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector3(0, 0, -Time.deltaTime * speed));
            desiredRot += 90;
            divider++;
            desiredYaw = yawRot;
            buttonDown = true;
        }
        //Count the desired rotation
        if (divider > 0)
        {
            desiredRot = desiredRot / divider; 
        }
        var desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, desiredRot, transform.eulerAngles.z);
        var desiredYawQ = Quaternion.Euler(desiredYaw, playerModel.transform.localEulerAngles.y, playerModel.transform.localEulerAngles.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ, Time.deltaTime * rotDampening);
        playerModel.transform.localRotation = Quaternion.Lerp(playerModel.transform.localRotation, desiredYawQ, Time.deltaTime * rotDampening);
        #endregion
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(interactable != null)
            {
                interactable.Interact();
            }
        }
        #endregion

        //Check if there are interactbles in the radius
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, interactRadius);
        int iCount = 0;
        for (int i = 0; i < hitColliders.Length; i++)
        {
            if(hitColliders[i].gameObject.tag == "Interactable")
            {
                iCount++;
                if (interactableInRadius == false)
                {
                    //Check if there is an obstacle between player and the interactable object
                    RaycastHit hit;
                    if (Physics.Raycast(new Ray(transform.position, hitColliders[i].transform.position - transform.position), out hit, Mathf.Infinity, layerMask))
                    {
                        Debug.DrawLine(transform.position, hit.point, Color.blue);
                        if (hit.transform.gameObject.tag == "Interactable")
                        {
                            interactable = hit.transform.GetComponent<IInteractable>();
                            interactable.PlayerInRange();
                            interactableInRadius = true;
                        }
                    } 
                }
            }
        }
        if (iCount == 0)
        {
            if (interactable != null && interactableInRadius == true)
            {
                interactableInRadius = false;
                interactable.PlayerOutRange();
                interactable = null;  
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, interactRadius);
    }
}
