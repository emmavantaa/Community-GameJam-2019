using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Transform fireRespawn;
    bool hit = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameManager.instance.player.transform.position = new Vector3(fireRespawn.position.x, GameManager.instance.player.transform.position.y, fireRespawn.position.z);
            if (hit == false)
            {
                NarratorManager.instance.ReadLines(new List<int> { 13 });
                hit = true;
            }
        }
    }
}
