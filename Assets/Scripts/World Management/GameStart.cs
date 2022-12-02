using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class GameStart : MonoBehaviour
{
    public PlayerInputManager playerInputManager;
    public GameObject ReadyTexts;
    public GameObject VRTexts;
    public TextMesh StartingInTextMesh;
    public GameObject theCube;
    public GameObject SpawnBox;
    public TMP_Text NumberOfPlayersTextMesh;
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

      foreach(GameObject VR_Player in GameObject.FindGameObjectsWithTag("VR"))
      {
        if(VR_Player.transform.childCount > 6)
        {
          VR_Player.transform.localScale = new Vector3((float)100, (float)100, (float)100);
          foreach(Transform collisionTransform in VR_Player.transform.GetChild(6))
          {
            collisionTransform.gameObject.SetActive(false);
          }
          foreach(Transform collisionTransform in VR_Player.transform.GetChild(7))
          {
            collisionTransform.gameObject.SetActive(false);
          }
        }
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
        foreach(Transform T in VRTexts.transform)
        {
          TextMesh vrTextMesh = T.gameObject.GetComponent<TextMesh>();
          vrTextMesh.text = "Waiting for Angels...";
        }
      }

      if(countingDown)
      {
        float timeLeft = timeEndCountDown - Time.realtimeSinceStartup;
        StartingInTextMesh.text = "Starting in " + (int)timeLeft;

        foreach(Transform T in VRTexts.transform)
        {
          TextMesh vrTextMesh = T.gameObject.GetComponent<TextMesh>();
          vrTextMesh.text = "Starting in " + (int)timeLeft;
        }

        if(timeLeft <= 0)
        {
          ReadyTexts.SetActive(false);

          foreach(Transform T in VRTexts.transform)
          {
            TextMesh vrTextMesh = T.gameObject.GetComponent<TextMesh>();
            vrTextMesh.text = "";
          }

          StartingInTextMesh.gameObject.SetActive(false);
          //playerInputManager.splitScreen = true;
          //playerInputManager.enabled = false;
          //playerInputManager.enabled = true;
          theCube.tag = "StartGame";
          SpawnBox.SetActive(false);
          EnemySpawnPoints.SetActive(true);
                foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
                {
                    gameObject.GetComponent<GameCues>().setCueText(0, player);
                }
          started = true;
        }
      }
      else
      {
        StartingInTextMesh.text = "";
      }
    }
}
