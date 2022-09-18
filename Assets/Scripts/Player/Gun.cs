using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject self;
    public Transform bulletSpawn;
    public GameObject bulletModel;
    public float bulletSpeed = 10;
    private const int LEFT_CLICK = 0;

    //update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(LEFT_CLICK))
        {
            var bullet = Instantiate(bulletModel, bulletSpawn.position, bulletSpawn.rotation);
            Physics.IgnoreCollision(self.GetComponent<Collider>(), bullet.GetComponent<Collider>());
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawn.forward * bulletSpeed;
        }
    }
}
