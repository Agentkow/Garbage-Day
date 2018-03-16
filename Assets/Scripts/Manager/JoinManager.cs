using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JoinManager : MonoBehaviour {
    
    [SerializeField]
    GameObject playerPrefab;

    [SerializeField]
    private Text player1ReadyText, player2ReadyText, statusText;

     [SerializeField]
    private TrashManager[] trashCans;

    public const int MaxPlayers = 2;

    private bool player1Joined, player2Joined;

   

    void Start () {
        player1ReadyText.gameObject.SetActive(false);
        player2ReadyText.gameObject.SetActive(false);

    }
	
	void Update ()
    {
        CheckForJoiningPlayers();
        CheckForStartingGame();

    }

    private void CheckForStartingGame()
    {
        if (player1Joined && player2Joined)
        {
            statusText.text = "Press Start to begin match";
            if (Input.GetButton("Submit"))
            {
                SceneManager.LoadScene("Level");
            }
        }
    }

    private void CheckForJoiningPlayers()
    {
        if (!player1Joined)
        {
            if (Input.GetButton("Fire1"))
            {
                player1ReadyText.gameObject.SetActive(true);
                trashCans[0].instance = Instantiate(playerPrefab, trashCans[0].spawnPoint.position, trashCans[0].spawnPoint.rotation);
                trashCans[0].playerNum = 1;
                trashCans[0].Setup();

                player1Joined = true;
            }

        }

        if (!player2Joined)
        {
            if (Input.GetButton("Fire2"))
            {
                player2ReadyText.gameObject.SetActive(true);
                trashCans[1].instance = Instantiate(playerPrefab, trashCans[1].spawnPoint.position, trashCans[1].spawnPoint.rotation);
                trashCans[1].playerNum = 2;
                trashCans[1].Setup();

                player2Joined = true;
            }
        }
    }
}
