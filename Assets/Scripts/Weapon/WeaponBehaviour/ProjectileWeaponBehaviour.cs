using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeaponBehaviour : MonoBehaviour
{
    public WeaponScriptable weaponData;

    protected float currentDamage,
        currentSpeed,
        currentCooldown,
        currentDurability,
        currentRadius,
        currentDestroySelf;

    void Awake()
    {
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldown = weaponData.Cooldown;
        currentDurability = weaponData.Durability;
        currentDestroySelf = weaponData.DestroySelf;
    }

    protected virtual void Start()
    {
        Destroy(gameObject, weaponData.DestroySelf);
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            EnemyStats enemy = col.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage);
        }
    }
}
