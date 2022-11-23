using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public GameObject Background;
    public Sprite game_menu;
    public Sprite slide_0;
    public Sprite slide_1;
    public Sprite slide_2;
    public Sprite slide_3;
    public GameObject button1;
    public GameObject button2;

    private bool inGameTips = false;
    private Image currentImage;
    private int slide = 0;
    private const int SLIDE_LENGTH = 3;
    private const int SLIDE_START = 0;
    
    //not in use anymore
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    //update is called once per frame
    void Update()
    {
        currentImage = Background.GetComponent<Image>();

        if (inGameTips)
        {
            //In Game Tips
            GameTips();
        } 
        else
        {
            //In Main Menu

            if (Input.GetMouseButtonDown(0))
                SceneManager.LoadScene("SampleScene");

            if (Input.GetMouseButtonDown(1))
            {
                button1.SetActive(false);
                button2.SetActive(false);
                inGameTips = true;
            }
        }

    }

    void GameTips()
    {
        switch(slide)
        {
            case 0:
                currentImage.sprite = slide_0;
                break;
            case 1:
                currentImage.sprite = slide_1;
                break;
            case 2:
                currentImage.sprite = slide_2;
                break;
            case 3:
                currentImage.sprite = slide_3;
                break;
        }
        
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (slide == SLIDE_LENGTH)
                slide = 0;
            else
                slide++;

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (slide == SLIDE_START)
                slide = SLIDE_LENGTH;
            else
                slide--;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            slide = 0;
            inGameTips = false;
            currentImage.sprite = game_menu;
            button1.SetActive(true);
            button2.SetActive(true);
        }

    }
}
