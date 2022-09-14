using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public int WeaponIndex = 0;

    //use this for initialization
    void Start()
    {
        WeaponSelect();
    }

    //update is called once per frame
    void Update()
    {
        int i = WeaponIndex;

        //assigning scroll wheel to select different weapons
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (WeaponIndex >= transform.childCount - 1)
                WeaponIndex = 0;
            else
                WeaponIndex++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (WeaponIndex <= 0)
                WeaponIndex = transform.childCount - 1;
            else
                WeaponIndex--;
        }

        if (i != WeaponIndex)
        {
            WeaponSelect();
        }
    }

    void WeaponSelect()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == WeaponIndex)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
