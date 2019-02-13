using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ElfDarkAnimatorEvents : MonoBehaviour {
    public void SetUpWeaponCollider()
    {
       if(GetComponentInChildren<WeaponInfomation>())
        {
            GetComponentInChildren<WeaponInfomation>().gameObject.GetComponent<Collider>().enabled = true;
        }
    }

    public void DisableWeaponCollider()
    {
        if (GetComponentInChildren<WeaponInfomation>())
        {
            GetComponentInChildren<WeaponInfomation>().gameObject.GetComponent<Collider>().enabled = false;
        }
    }

}
