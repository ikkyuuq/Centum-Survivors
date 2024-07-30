using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : WeaponController
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject weapon = Instantiate(weaponData.Prefab);
        weapon.transform.position = transform.position;
    }
}
