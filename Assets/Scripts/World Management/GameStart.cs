using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameStart : MonoBehaviour
{
    public PlayerInputManager playerInputManager;
    public GameObject ReadyTexts;
    public TextMesh StartingInTextMesh;
    public GameObject theCube;
    public GameObject SpawnBox;
    public TextMesh NumberOfPlayersTextMesh;
    public GameObject EnemySpawnPoints;

    private bool countingDown;
    private float timeEndCountDown;
    private float timeNow;
    private bool started;

    // Start is called before the first frame update
    void Start()
    {
      countingDown = false;
      started = false;
    }

    // Update is called once per frame
    void Update()
    {
      if(started == true)
      {
        return;
      }
      if(playerInputManager.playerCount > 1)
      {
        NumberOfPlayersTextMesh.text = playerInputManager.playerCount + " Players";
      }
      else
      {
        NumberOfPlayersTextMesh.text = "1 Player";
      }
      /*
      int playerIndex = 0;

      foreach(GameObject player in GameObject.FindGameObjectsWithTag("Player"))
      {
        Debug.Log(player.transform.position);
        Transform associatedReadyText = ReadyTexts.transform.GetChild(playerIndex);
        player.transform.position = new Vector3(associatedReadyText.position.x, 1, associatedReadyText.position.z);
        playerIndex++;
      }*/



      for(int i = 0; i < playerInputManager.playerCount; i++)
      {
        ReadyTexts.transform.GetChild(i).gameObject.SetActive(true);
      }
      for(int i = 3; i >= playerInputManager.playerCount; i--)
      {
        ReadyTexts.transform.GetChild(i).gameObject.SetActive(false);
      }

      int numberOfPlayers = playerInputManager.playerCount;
      int numberOfReadyPlayers = GameObject.FindGameObjectsWithTag("Ready").Length;
      if((numberOfPlayers == numberOfReadyPlayers) && !countingDown)
      {
        timeEndCountDown = Time.realtimeSinceStartup + (float)6;
        countingDown = true;
      }

      if(numberOfPlayers != numberOfReadyPlayers)
      {
        countingDown = false;
      }

      if(countingDown)
      {
        float timeLeft = timeEndCountDown - Time.realtimeSinceStartup;
        StartingInTextMesh.text = "Starting in " + (int)timeLeft;

        if(timeLeft <= 0)
        {
          ReadyTexts.SetActive(false);
          StartingInTextMesh.gameObject.SetActive(false);
          //playerInputManager.splitScreen = true;
          //playerInputManager.enabled = false;
          //playerInputManager.enabled = true;
          theCube.tag = "StartGame";
          SpawnBox.SetActive(false);
          EnemySpawnPoints.SetActive(true);
          started = true;
        }
      }
      else
      {
        StartingInTextMesh.text = "";
      }
    }
}
