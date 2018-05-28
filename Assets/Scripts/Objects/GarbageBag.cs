using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageBag : MonoBehaviour 
{
    [SerializeField]
    private AudioSource canCollide;

    private void Start()
    {
        canCollide = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canCollide.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "OutBound")
        {
            Destroy(gameObject);
        }
    }
}
