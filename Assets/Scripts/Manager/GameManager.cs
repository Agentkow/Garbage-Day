using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject playerPrefab;
    public GameObject leftLawn;
    public GameObject rightLawn;
    public TrashManager[] trashCans;
    public Text leftText;
    public Text rightText;
    public float timer = 120f;

    private BagCounter leftPlayer;
    private BagCounter rightPlayer;
    private int leftCount;
    private int rightCount;

    private void Awake()
    {
        leftLawn = GameObject.Find("HomeL");
        rightLawn = GameObject.Find("HomeR");
        leftPlayer = leftLawn.GetComponent<BagCounter>();
        rightPlayer = rightLawn.GetComponent<BagCounter>();
    }

    private void Start()
    {
        SpawnCans();
        StartCoroutine(TimerCountdown());
    }

    private void SpawnCans()
    {
        for (int i = 0; i < trashCans.Length; i++)
        {
            trashCans[i].instance = Instantiate(playerPrefab, trashCans[i].spawnPoint.position, trashCans[i].spawnPoint.rotation) as GameObject;
            trashCans[i].playerNum = i + 1;
            trashCans[i].Setup();
        }

        
    }

    private void FixedUpdate()
    {
        leftCount = leftPlayer.bagCount;
        rightCount = rightPlayer.bagCount;

        leftText.text = "Bags: " + leftCount;
        rightText.text = "Bags: " + rightCount;
    }

    private IEnumerator TimerCountdown()
    {

        yield return new WaitForSeconds(timer);
    }
}
