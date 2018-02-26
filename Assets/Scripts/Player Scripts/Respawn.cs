using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour 
{
    public Transform spawnPoint;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "OutBound")
        {
            transform.position = spawnPoint.position; 
        }
    }
}
