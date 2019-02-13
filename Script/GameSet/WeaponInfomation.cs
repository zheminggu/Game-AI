using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInfomation : MonoBehaviour {
    public float m_WeaponDamage { get { return weaponDamage; } }
    [SerializeField]
    private float weaponDamage =10f;


}
