using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour 
{
    public int playerNum = 1;
    public float speed = 12f;
    public float turnSpeed = 180f;

    private string movementAxis;
    private string turnAxis;

    private Rigidbody rigBody;

    private float movementInput;
    private float turnInput;


    private void Awake()
    {
        rigBody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        rigBody.isKinematic = false;
        movementInput = 0f;
        turnInput = 0f;
    }

    private void OnDisable()
    {
        rigBody.isKinematic = true;
    }

    // Use this for initialization
    void Start () 
	{
        movementAxis = "Vertical" + playerNum;
        turnAxis = "Horizontal" + playerNum;
	}
	
	// Update is called once per frame
	void Update () 
	{
        movementInput = Input.GetAxis(movementAxis);
        turnInput = Input.GetAxis(turnAxis);
	}

    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    private void Turn()
    {
        float turn = turnInput * turnSpeed * Time.deltaTime;
        Quaternion turnRotate = Quaternion.Euler(0f, turn, 0f);
        rigBody.MoveRotation(rigBody.rotation * turnRotate);
    }

    private void Move()
    {
        Vector3 movement = transform.forward * movementInput * speed * Time.deltaTime;
        rigBody.MovePosition(rigBody.position + movement);
    }
}
