using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameQueues : MonoBehaviour
{
    int idx = 0;
    public Transform QueueTexts;

    public void setQueueText (int index)
    {
        idx = index;
        foreach (Transform kid in QueueTexts)
        {
            kid.gameObject.SetActive(false);
        }
        QueueTexts.GetChild(idx).gameObject.SetActive(true);
        StartCoroutine(WaitALilBit());
    }

    IEnumerator WaitALilBit()
    {
        yield return new WaitForSeconds(3.0f);
        QueueTexts.GetChild(idx).gameObject.SetActive(false);
    }
}
