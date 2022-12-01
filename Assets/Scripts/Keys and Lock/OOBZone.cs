using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOBZone : MonoBehaviour
{
    public GameObject HitParticles;
    public GameObject CueManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //This function causes damage over time if the Quadrant is Locked and there is a player in the quadrant
    void OnTriggerStay(Collider collider)
    {
        if (collider.TryGetComponent<Health>(out Health enemy) && !enemy.isDead)
        {
            float x = collider.transform.position.x;
            float y = collider.transform.position.y;
            float z = collider.transform.position.z;

            Quaternion rotation = collider.transform.rotation;

            enemy.TakeDamage(1f);
            Instantiate(HitParticles, new Vector3(x, y, z), rotation);
            CueManager.GetComponent<GameCues>().setCueText(3, collider.gameObject);
        }
    }
}
