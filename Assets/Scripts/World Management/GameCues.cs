using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCues : MonoBehaviour
{
    int idx = 0;
    GameObject gmr;
    public AudioClip notify;

    public void setCueText (int index, GameObject gamer)
    {
        idx = index;
        gmr = gamer;
        gmr.transform.GetChild(0).GetComponent<Camera>().cullingMask |= 1 << LayerMask.NameToLayer("CueTexts");
        foreach (Transform kid in gmr.transform.GetChild(0).GetChild(1))
        {
            kid.gameObject.SetActive(false);
        }
        gmr.transform.GetChild(0).GetChild(1).GetChild(idx).gameObject.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(notify);
        StartCoroutine(WaitALilBit());
    }

    IEnumerator WaitALilBit()
    {
        yield return new WaitForSeconds(3.0f);
        gmr.transform.GetChild(0).GetChild(1).GetChild(idx).gameObject.SetActive(false);
        gmr.transform.GetChild(0).GetComponent<Camera>().cullingMask &= ~(1 << LayerMask.NameToLayer("CueTexts"));
    }
}
