// 20 lines
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemyScriptable enemyData;
    float currentMoveSpeed,
        currentHealth,
        currentDamage;

    void Awake()
    {
        currentMoveSpeed = enemyData.MoveSpeed;
        currentHealth = enemyData.MaxHealth;
        currentDamage = enemyData.Damage;
    }

    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;
        if (currentHealth <= 0)
            Destroy(gameObject);
    }

    private void OnDestroy()
    {
        EnemySpawner es = FindObjectOfType<EnemySpawner>();
        es.OnKilled();
    }
}
