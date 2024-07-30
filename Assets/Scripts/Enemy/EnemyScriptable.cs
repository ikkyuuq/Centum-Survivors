// 18 lines
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptable", menuName = "Enemy")]
public class EnemyScriptable : ScriptableObject
{
    [SerializeField]
    public GameObject enemyPrefab;
    public GameObject Prefab
    {
        get => enemyPrefab;
        private set => enemyPrefab = value;
    }

    [SerializeField]
    public float damage;
    public float Damage
    {
        get => damage;
        private set => damage = value;
    }

    [SerializeField]
    public float moveSpeed;
    public float MoveSpeed
    {
        get => moveSpeed;
        private set => moveSpeed = value;
    }

    [SerializeField]
    public float maxHealth;
    public float MaxHealth
    {
        get => maxHealth;
        private set => maxHealth = value;
    }
}
