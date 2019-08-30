using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Transform fireRespawn;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameManager.instance.player.transform.position = new Vector3(fireRespawn.position.x, GameManager.instance.player.transform.position.y, fireRespawn.position.z);
        }
    }
}
