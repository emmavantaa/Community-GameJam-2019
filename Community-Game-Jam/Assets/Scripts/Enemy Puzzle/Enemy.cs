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
    public int patrolSpeed;
    public int patrolAcceleration;
    public int playerInSightSpeed;
    public int playerInSightAcceleration;
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

        if (Physics.SphereCast(transform.position, 7.5f , transform.TransformDirection(Vector3.forward) * 30, out hit, 30))
        {
            if(hit.transform.gameObject.tag == "Player" && GameManager.instance.player.camouflaged == false)
            {
                Debug.DrawLine(transform.position, hit.point, Color.blue);
                playerInSight = true;
                GameManager.instance.player.enemySeen = true;
                GetComponent<NavMeshAgent>().speed = playerInSightSpeed;
                GetComponent<NavMeshAgent>().acceleration = playerInSightAcceleration;
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
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player" && GameManager.instance.player.camouflaged == false)
        {
            GameManager.instance.player.transform.position = new Vector3(GameManager.instance.enemyRespawn.position.x, other.gameObject.transform.position.y, GameManager.instance.enemyRespawn.position.z);
            if(GameManager.instance.enemyHit == false)
            {
                GameManager.instance.enemyHit = true;
                NarratorManager.instance.ReadLines(new List<int> { 19 });
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position + transform.TransformDirection(Vector3.forward) * 30, 7.5f);
        Gizmos.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 30);
    }

    void Patrol()
    {
        GetComponent<NavMeshAgent>().speed = patrolSpeed;
        GetComponent<NavMeshAgent>().acceleration = patrolAcceleration;
        playerInSight = false;
        GameManager.instance.player.enemySeen = false;
        if (agent.remainingDistance < agent.stoppingDistance + 3)
        {
            if(patrolPointIndex < patrolPoints.Count - 1)
            {
                patrolPointIndex++;
            }
            else
            {
                patrolPointIndex = 0;
            }
            target = patrolPoints[patrolPointIndex];
            agent.SetDestination(new Vector3(target.position.x, transform.localPosition.y, target.localPosition.z));
        }
        else
        {
            target = patrolPoints[patrolPointIndex];
            agent.SetDestination(new Vector3(target.position.x, transform.position.y, target.position.z));
        }
    }
}
