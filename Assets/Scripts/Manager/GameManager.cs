using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private GameObject playerPrefab;

    [SerializeField]
    private GameObject leftLawn;

    [SerializeField]
    private GameObject rightLawn;

    [SerializeField]
    private TrashManager[] trashCans;

    [SerializeField]
    private Text leftText;

    [SerializeField]
    private Text rightText;

    [SerializeField]
    private Text timerText;

    [SerializeField]
    private float timer = 120f;

    [SerializeField]
    private Text winMessageText;

    [SerializeField]
    private float returnMainMenuDelay = 1f;

    private bool gameHasEnded = false;
    private BagCounter leftPlayer;
    private BagCounter rightPlayer;
    private int leftCount;
    private int rightCount;

    private void Awake()
    {
        
        leftPlayer = leftLawn.GetComponent<BagCounter>();
        rightPlayer = rightLawn.GetComponent<BagCounter>();
    }

    private void Start()
    {
        winMessageText.text = "";
        SpawnCans();

    }

    private void SpawnCans()
    {
        for (int i = 0; i < trashCans.Length; i++)
        {
            trashCans[i].instance = Instantiate(playerPrefab, trashCans[i].spawnPoint.position, trashCans[i].spawnPoint.rotation);
            trashCans[i].playerNum = i+1;
            trashCans[i].Setup();
        }

    }

    private void FixedUpdate()
    {

        float minutes = Mathf.Floor(timer / 60);
        float seconds = Mathf.RoundToInt(timer % 60);

        leftCount = leftPlayer.bagCount;
        rightCount = rightPlayer.bagCount;

        leftText.text = "Bags: " + leftCount;
        rightText.text = "Bags: " + rightCount;

        
        if (!gameHasEnded)
        {
            timerText.text = minutes + ":" + seconds;
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                EndGame();
            }
        }
        
        
    }

    private void EndGame()
    {
        gameHasEnded = true;
        for (int i = 0; i < trashCans.Length; i++)
        {
            trashCans[i].DisableControl();
        }

        winMessageText.text = GetWinMessage();
        timerText.text = "";
        StartCoroutine(ReturnToMainMenuAfterDelay());
    }

    private string GetWinMessage()
    {
        if (leftCount < rightCount)
        {
            return "Player 1 Wins!";
        }
        else if (leftCount > rightCount)
        {
            return "Player 2 Wins!";
        }
        else
        {
            return "Draw!";
        }
    }

   
    private IEnumerator ReturnToMainMenuAfterDelay()
    {
        yield return new WaitForSeconds(returnMainMenuDelay);
        SceneManager.LoadScene("Main Menu");
    }
}
