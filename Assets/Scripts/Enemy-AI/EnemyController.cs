using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;

    public float lookRadius = 80f;
    public float attackRadius = 2f;

    public GameObject Hands;

    //start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    //update is called once per frame
    void Update()
    {
        GameObject nearestPlayerObject = GameObject.FindWithTag("Player");
        foreach(GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (((Vector3.Distance(transform.position, player.transform.position) 
                < Vector3.Distance(transform.position, nearestPlayerObject.transform.position))
                || nearestPlayerObject.GetComponent<Health>().isDead)
                && !player.GetComponent<Health>().isDead)
            {
                nearestPlayerObject = player;
            }
        }
        target = nearestPlayerObject.transform;

        float distance = Vector3.Distance(target.position, transform.position);

        //System.Console.WriteLine("Distance from player: " + distance);

        if (distance < lookRadius && !nearestPlayerObject.GetComponent<Health>().isDead)
        {
            agent.SetDestination(target.position);
            if (distance < attackRadius)
            {
                FaceTarget();
                //attack the target
                if (Hands.TryGetComponent<EnemyMeleeController>(out EnemyMeleeController temp))
                {
                    if (temp.CanAttack)
                    {
                        GetComponent<Animator>().SetTrigger("Attack");
                        temp.MeleeAttack();
                    }
                }
            }
            else
            {
                GetComponent<Animator>().SetTrigger("TargetFound");
            }
        }
        else
        {
            GetComponent<Animator>().SetTrigger("TargetLost");
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        //smooth out our transition
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
