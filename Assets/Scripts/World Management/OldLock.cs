using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldLock : MonoBehaviour
{
    public GameObject quadrant;
    public GameObject player;
    private Transform playerTransform;
    private bool alreadyUnlocked;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
      playerTransform = player.transform;
      alreadyUnlocked = false;
    }

    // Update is called once per frame
    void Update()
    {
      distance = Vector3.Distance(playerTransform.position, transform.position);
      Debug.Log(distance);
      if(distance < 2 && !alreadyUnlocked)
      {
        unlock();
      }
    }

    private void unlock()
    {
      quadrant.SetActive(false);
      alreadyUnlocked = true;
    }
}
