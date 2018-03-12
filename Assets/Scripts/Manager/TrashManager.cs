using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class TrashManager
{
    public Transform spawnPoint;
    [HideInInspector] public int playerNum;
    [HideInInspector] public GameObject instance;
    [HideInInspector] public int wins;

    private Movement movement;
    private Shoot shooting;


    public void Setup()
    {
        movement = instance.GetComponent<Movement>();
        shooting = instance.GetComponent<Shoot>();

        movement.playerNum = playerNum;

        movement.playerNum = playerNum;
        shooting.playerNum = playerNum;

    }

	public void DisableControl()
    {
        movement.enabled = false;
        shooting.enabled = false;
    }

    public void EnableControl()
    {
        movement.enabled = true;
        shooting.enabled = true;
    }

    public void Reset()
    {
        instance.transform.position = spawnPoint.position;
        instance.transform.rotation = spawnPoint.rotation;

        instance.SetActive(false);
        instance.SetActive(true);
    }


}
