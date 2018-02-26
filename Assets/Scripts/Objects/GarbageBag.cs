using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageBag : MonoBehaviour 
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "OutBound")
        {
            Destroy(gameObject);
        }
    }
}
