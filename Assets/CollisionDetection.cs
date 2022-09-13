using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public WeaponController weaponController;
    public GameObject HitParticle;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" && weaponController.IsAttacking)
        {
            float X = other.transform.position.x;
            float Y = other.transform.position.y;
            float Z = other.transform.position.z;

            Quaternion ROTATION = other.transform.rotation;

            string NAME = other.name;

            Debug.Log(NAME);
            other.GetComponent<Animator>().SetTrigger("Hit");
            Instantiate(HitParticle, new Vector3(X,Y,Z), ROTATION);
        }
    }
}
