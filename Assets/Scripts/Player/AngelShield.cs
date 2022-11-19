using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelShield : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<EnemyController>(out EnemyController enemy))
        {
            enemy.agent.speed = 0f;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent<EnemyController>(out EnemyController enemy))
        {
            enemy.agent.speed = 5f;
        }
    }
}
