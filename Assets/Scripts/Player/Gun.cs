using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public GameObject self;
    public Transform bulletSpawn;
    public GameObject bulletModel;
    public float bulletSpeed = 10;
    public AudioClip ShootAttackSound;

    private const int LEFT_CLICK = 0;

    public PlayerInput playerInput;
    private InputActionAsset playerInputActionAsset;
    public float fireDelay;
    private float lastFired = 0;

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
