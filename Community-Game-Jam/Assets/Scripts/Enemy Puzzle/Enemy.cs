using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;
    public bool playerInSight;
    public List<Transform> patrolPoints = new List<Transform>();
    private int patrolPointIndex;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(patrolPoints[patrolPointIndex].position);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.SphereCast(transform.position, 0.75f , transform.TransformDirection(Vector3.forward) * 3, out hit, 3))
        {
            if(hit.transform.gameObject.tag == "Player")
            {
                Debug.DrawLine(transform.position, hit.point, Color.blue);
                playerInSight = true;
                GameManager.instance.player.enemySeen = true;
            }
            else
            {
                Patrol();
            }
        }
        else
        {
            Patrol();
        }
        if (playerInSight == true && GameManager.instance.player.camouflaged == false)
        {
            agent.SetDestination(hit.transform.position);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position + transform.TransformDirection(Vector3.forward) * 3, 0.75f);
        Gizmos.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 3);
    }

    void Patrol()
    {
        playerInSight = false;
        GameManager.instance.player.enemySeen = false;
        if (transform.position.x == patrolPoints[patrolPointIndex].position.x && transform.position.z == patrolPoints[patrolPointIndex].position.z)
        {
            if(patrolPointIndex < patrolPoints.Count - 1)
            {
                patrolPointIndex++;
            }
            else
            {
                patrolPointIndex = 0;
            }
            agent.SetDestination(patrolPoints[patrolPointIndex].position);
        }
        else
        {
            agent.SetDestination(patrolPoints[patrolPointIndex].position);
        }
    }
}
