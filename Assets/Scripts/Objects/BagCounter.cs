using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagCounter : MonoBehaviour {

    public int bagCount;

    private void OnTriggerEnter(Collider other)
    {
        bagCount++;
    }

    private void OnTriggerExit(Collider other)
    {
        bagCount--;  
    }
}
