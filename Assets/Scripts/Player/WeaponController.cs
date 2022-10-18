using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    public int WeaponIndex = 0;
    public InputActionAsset playerInputActionAsset;

    //use this for initialization
    void Start()
    {
        WeaponSelect();
    }

    //update is called once per frame
    void Update()
    {
        int i = WeaponIndex;

        float mouseScroll = playerInputActionAsset.actionMaps[0].actions[4].ReadValue<float>();

        //assigning scroll wheel to select different weapons
        if (mouseScroll > 0f)
        {
            if (WeaponIndex >= transform.childCount - 1)
                WeaponIndex = 0;
            else
                WeaponIndex++;
        }
        if (mouseScroll < 0f)
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

        bool switchToWeapon1 = playerInputActionAsset.actionMaps[0].actions[5].ReadValue<float>() == 1;
        bool switchToWeapon2 = playerInputActionAsset.actionMaps[0].actions[6].ReadValue<float>() == 1;

        if(switchToWeapon1)
        {
          SwitchToWeapon1();
        }
        else if(switchToWeapon2)
        {
          SwitchToWeapon2();
        }
    }

    void WeaponSelect()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (weapon.TryGetComponent<Animator>(out Animator temp) && temp.GetCurrentAnimatorStateInfo(0).IsName("Sword-Attack"))
                WeaponIndex = 0;
            else if (i == WeaponIndex)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }

    void SwitchToWeapon1()
    {
      transform.GetChild(1).gameObject.SetActive(false);
      transform.GetChild(0).gameObject.SetActive(true);
    }

    void SwitchToWeapon2()
    {
      transform.GetChild(0).gameObject.SetActive(false);
      transform.GetChild(1).gameObject.SetActive(true);
    }
}
