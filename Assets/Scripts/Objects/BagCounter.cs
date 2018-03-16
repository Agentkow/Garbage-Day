using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagCounter : MonoBehaviour {

    public int bagCount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bag")
        {
            bagCount++;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Bag")
        {
            bagCount--;
        }
         
    }
}
