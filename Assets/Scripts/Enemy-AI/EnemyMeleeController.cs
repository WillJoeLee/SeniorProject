using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeController : MonoBehaviour
{
    //variables for enemy attacks
    public GameObject self;
    public GameObject Hands;
    public bool CanAttack = true;
    public AudioClip MeleeAttackSound;
    public GameObject HitParticles;

    //collision detection
    public bool IsAttacking = false;

    //start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(self.GetComponent<Collider>(), GetComponent<Collider>());
    }

    public void MeleeAttack()
    {
        IsAttacking = true;
        CanAttack = false;
        Hands.GetComponent<Animator>().SetTrigger("Attack");
        //GetComponent<AudioSource>().PlayOneShot(MeleeAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    //co-routine's
    IEnumerator ResetAttackCooldown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(1.0f);
        CanAttack = true;
    }

    IEnumerator ResetAttackBool()
    {
        //set to length of final animation, for now default 1 sec
        yield return new WaitForSeconds(1.0f);
        IsAttacking = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (IsAttacking && collision.gameObject.TryGetComponent<Health>(out Health enemy))
        {
            float x = collision.gameObject.transform.position.x;
            float y = collision.gameObject.transform.position.y;
            float z = collision.gameObject.transform.position.z;

            Quaternion rotation = collision.gameObject.transform.rotation;

            //collision.gameObject.GetComponent<Animator>().SetTrigger("IsHurt");

            if (!enemy.isDead)
            {
                enemy.TakeDamage(5);
                Instantiate(HitParticles, new Vector3(x, y, z), rotation);
            }
        }
    }
}
