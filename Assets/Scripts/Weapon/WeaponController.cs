using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public WeaponScriptable weaponData;
    float currCooldown;

    protected virtual void Start()
    {
        currCooldown = weaponData.Cooldown;
    }

    protected virtual void Update()
    {
        currCooldown -= Time.deltaTime;
        if (currCooldown <= 0f)
        {
            Attack();
        }
    }

    protected virtual void Attack()
    {
        currCooldown = weaponData.Cooldown;
    }
}
