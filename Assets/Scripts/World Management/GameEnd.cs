using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    public bool winGame = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (winGame)
        {
            SceneManager.LoadScene("SampleScene");
            winGame = false;
        }
    }
}
