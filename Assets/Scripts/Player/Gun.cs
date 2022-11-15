using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public GameObject self;
    public Transform bulletSpawn;
    public GameObject bulletModel;
    public float bulletSpeed;
    public AudioClip ShootAttackSound;

    public PlayerInput playerInput;
    private InputActionAsset playerInputActionAsset;
    private float lastFired = 0;
    public float fireDelay;

    void Start()
    {
      playerInputActionAsset = playerInput.actions;
    }

    //update is called once per frame
    void Update()
    {
        bool attackBool = playerInputActionAsset.actionMaps[0].actions[3].ReadValue<float>() == (float)1;
        if (attackBool && (Time.realtimeSinceStartup - lastFired) > fireDelay)
        {
            lastFired = Time.realtimeSinceStartup;
            var bullet = Instantiate(bulletModel, bulletSpawn.position, bulletSpawn.rotation);
            Physics.IgnoreCollision(self.GetComponent<Collider>(), bullet.GetComponent<Collider>());
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawn.forward * bulletSpeed;
            //AudioSource ac = GetComponent<AudioSource>();
            //ac.PlayOneShot(SwordAttackSound);
        }
    }
}
