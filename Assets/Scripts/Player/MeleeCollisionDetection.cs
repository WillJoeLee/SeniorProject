using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCollisionDetection : MonoBehaviour
{
    public GameObject self;
    public MeleeWeapon Sword;
    public GameObject HitParticles;

    //start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(self.GetComponent<Collider>(), Sword.GetComponent<Collider>());
    }

    void OnCollisionEnter(Collision collision)
    {
        if (Sword.IsAttacking && collision.gameObject.TryGetComponent<Health>(out Health enemy))
        {
            float x = collision.gameObject.transform.position.x;
            float y = collision.gameObject.transform.position.y;
            float z = collision.gameObject.transform.position.z;

            Quaternion rotation = collision.gameObject.transform.rotation;

            //collision.gameObject.GetComponent<Animator>().SetTrigger("Hit");
            Instantiate(HitParticles, new Vector3(x, y, z), rotation);

            enemy.TakeDamage(35);
        }
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" && Sword.IsAttacking)
        {
            float X = other.transform.position.x;
            float Y = other.transform.position.y;
            float Z = other.transform.position.z;

            Quaternion ROTATION = other.transform.rotation;

            string NAME = other.name;

            Debug.Log(NAME);
            other.GetComponent<Animator>().SetTrigger("Hit");
            Instantiate(HitParticles, new Vector3(X,Y,Z), ROTATION);
        }
    }
    */
}
