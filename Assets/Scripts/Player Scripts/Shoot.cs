﻿using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public int playerNum = 1;
    public Rigidbody bag;
    public Transform fireTransform;

    public float force = 5.95f;
    public float coolDown = 0.1f;

    private string fireButton;
    private float currentForce;
    private float chargeSpeed;
    private bool fired;
    private bool canFire;

    private void OnEnable()
    {
        currentForce = force;
    }
    
    void Start ()
    {
        fireButton = "Fire" + playerNum;
        canFire = true;

	}
	
	void Update ()
    {
       
        if (canFire)
        {
            if (Input.GetButtonDown(fireButton))
            {
                Fire();
                StartCoroutine(CoolDown());
            }
            else
            {
                fired = false;
            }
        }
       
    }

    //launch trashcan
    private void Fire()
    {
        fired = false;
        Rigidbody instance = Instantiate(bag, fireTransform.position, fireTransform.rotation);

        instance.velocity = force * fireTransform.forward;
        
    }

    //cooldown
    private IEnumerator CoolDown()
    {
        canFire = false;
        yield return new WaitForSeconds(coolDown);
        canFire = true;
    }
}
