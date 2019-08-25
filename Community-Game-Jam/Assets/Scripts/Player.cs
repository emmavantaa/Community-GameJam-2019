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
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(new Vector3(-Time.deltaTime * speed, 0, 0));
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector3(0, 0, Time.deltaTime * speed));
            transform.eulerAngles = new Vector3(0, -90, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector3(0, 0, -Time.deltaTime * speed));
            transform.eulerAngles = new Vector3(0, 90, 0);
        }
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
                        Debug.DrawLine(transform.position, hit.transform.position, Color.blue);
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
