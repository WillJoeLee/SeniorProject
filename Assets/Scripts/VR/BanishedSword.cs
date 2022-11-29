using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanishedSword : MonoBehaviour
{
    public float swordSpeed = (float)1;
    public float despawnAfterCollide = (float)5;
    public float despawnNoMatterCollide = (float)30;

    // Start is called before the first frame update
    void Start()
    {
      GameObject.Destroy(transform.gameObject, despawnNoMatterCollide);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
      transform.position = transform.position + transform.forward * swordSpeed;

      if(transform.position.y <= (float)0.2)
      {
        swordSpeed = (float)0;
        transform.GetChild(6).gameObject.SetActive(true);
        GameObject.Destroy(transform.gameObject, despawnAfterCollide);
      }
    }
}
