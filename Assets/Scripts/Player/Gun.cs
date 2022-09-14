using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bulletModel;
    public float bulletSpeed = 10;
    private const int LEFT_CLICK = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(LEFT_CLICK))
        {
            var bullet = Instantiate(bulletModel, bulletSpawn.position, bulletSpawn.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawn.forward * bulletSpeed;
        }
    }
}
