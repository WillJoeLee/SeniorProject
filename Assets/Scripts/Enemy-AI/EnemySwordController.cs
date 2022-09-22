using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwordController : MonoBehaviour
{
    //variables for enemy attacks
    public GameObject Sword;
    public bool CanAttack = true;
    public float AttackCooldown = 1.0f;
    public AudioClip SwordAttackSound;

    private const string ATTACK = "Attack";
    private const float ONE_SECOND = 1.0f;

    //collision detection
    public bool IsAttacking = false;

    public GameObject self;
    public GameObject HitParticles;

    //start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(self.GetComponent<Collider>(), GetComponent<Collider>());
    }

    public void SwordAttack()
    {
        IsAttacking = true;
        CanAttack = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger(ATTACK);
        //AudioSource ac = GetComponent<AudioSource>();
        //ac.PlayOneShot(SwordAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    //co-routine's
    IEnumerator ResetAttackCooldown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
    }

    IEnumerator ResetAttackBool()
    {
        //set to length of final animation, for now default 1 sec
        yield return new WaitForSeconds(ONE_SECOND);
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

            //collision.gameObject.GetComponent<Animator>().SetTrigger("Hit");
            Instantiate(HitParticles, new Vector3(x, y, z), rotation);

            enemy.TakeDamage(15);
        }
    }
}
