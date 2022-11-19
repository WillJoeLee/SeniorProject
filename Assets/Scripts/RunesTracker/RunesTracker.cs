using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RunesTracker : MonoBehaviour
{
    const string RUNE_E = "rune-e";
    const string RUNE_H = "rune-h";
    const string RUNE_R = "rune-r";
    const string RUNE_X = "rune-x";

    public Image Rune_E_Image;
    public Image Rune_H_Image;
    public Image Rune_R_Image;
    public Image Rune_X_Image;

    public void SetActiveRune(string rune)
    {
        switch (rune)
        {
            case RUNE_E:
                // set e as active
                Rune_E_Image.GetComponent<Image>().color = new Color32(0, 255, 255, 255);
                break;
            case RUNE_H:
                // set h as active
                Rune_H_Image.GetComponent<Image>().color = new Color32(0, 255, 255, 255);
                break;
            case RUNE_R:
                // set r as active
                Rune_R_Image.GetComponent<Image>().color = new Color32(0, 255, 255, 255);
                break;
            case RUNE_X:
                // set x as active
                Rune_X_Image.GetComponent<Image>().color = new Color32(0, 255, 255, 255);
                break;
        }

    }

    public void SetDeactiveRune(string rune)
    {
        switch (rune)
        {
            case RUNE_E:
                // set e as not active
                Rune_E_Image.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                break;
            case RUNE_H:
                // set h as not active
                Rune_H_Image.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                break;
            case RUNE_R:
                // set r as not active
                Rune_R_Image.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                break;
            case RUNE_X:
                // set x as not active
                Rune_X_Image.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                break;
        }

    }

    public void ActivateRunes()
    {
        Rune_E_Image.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        Rune_H_Image.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        Rune_R_Image.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        Rune_X_Image.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
    }

    public void DisableRunes()
    {
        Rune_E_Image.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
        Rune_H_Image.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
        Rune_R_Image.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
        Rune_X_Image.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
    }
}
