using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour {

    public int playerNum = 1;
    public Rigidbody bag;
    public Transform fireTransform;
    public Slider aimSlider;

    public float minForce = 15;
    public float maxForce = 30;
    public float maxCharge = 0.75f;

    public string fireButton;
    private float currentForce;
    private float chargeSpeed;
    private bool fired;

    private void OnEnable()
    {
        currentForce = minForce;
        aimSlider.value = minForce;
    }

    // Use this for initialization
    void Start ()
    {
        fireButton = "Fire" + playerNum;
        chargeSpeed = (maxForce - minForce) / maxCharge;


	}
	
	// Update is called once per frame
	void Update ()
    {
        aimSlider.value = minForce;
        if (currentForce>=maxCharge&& !fired)
        {
            currentForce = maxForce;
            Fire();
        }
        else if (Input.GetButtonDown(fireButton))
        {
            fired = false;
            currentForce = minForce;
        }
        else if (Input.GetButton(fireButton) && !fired)
        {
            currentForce += chargeSpeed * Time.deltaTime;
            aimSlider.value = currentForce;
        }
        else if (Input.GetButtonUp(fireButton) && !fired)
        {
            Fire();
        }
    }

    private void Fire()
    {
        fired = true;

        Rigidbody instance = Instantiate(bag, fireTransform.position, fireTransform.rotation) as Rigidbody;

        instance.velocity = currentForce * fireTransform.forward;

        currentForce = minForce;
    }
}
