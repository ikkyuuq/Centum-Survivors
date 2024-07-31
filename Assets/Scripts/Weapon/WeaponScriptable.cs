// 30 lines
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponScriptable", menuName = "Weapon")]
public class WeaponScriptable : ScriptableObject
{
    [SerializeField]
    private GameObject prefab;
    public GameObject Prefab
    {
        get => prefab;
        private set => prefab = value;
    }

    [SerializeField]
    private float damage;
    public float Damage
    {
        get => damage;
        private set => damage = value;
    }

    [SerializeField]
    private float speed;
    public float Speed
    {
        get => speed;
        private set => speed = value;
    }

    [SerializeField]
    private float radius;
    public float Radius
    {
        get => radius;
        private set => radius = value;
    }

    [SerializeField]
    private float cooldown;
    public float Cooldown
    {
        get => cooldown;
        private set => cooldown = value;
    }

    [SerializeField]
    private float durability;
    public float Durability
    {
        get => durability;
        private set => durability = value;
    }

    [SerializeField]
    private float destroyself;
    public float DestroySelf
    {
        get => destroyself;
        private set => destroyself = value;
    }
}
