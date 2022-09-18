using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitParticles : MonoBehaviour
{
    public float life = 1f;

    void Awake()
    {
        Destroy(gameObject, life);
    }
}
