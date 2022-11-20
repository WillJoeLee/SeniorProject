using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //not in use anymore
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    //update is called once per frame
    void Update()
    {
        //working
        if (Input.GetMouseButtonDown(0))
            SceneManager.LoadScene("SampleScene");
        //not in use yet
        if (Input.GetMouseButtonDown(1))
            return;
    }
}
