using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float maxHP;
    private float currentHP;

    [SerializeField] private float attackDamage;

    private void Start()
    {
        currentHP = maxHP;
    }

    private void Update()
    {
        if (currentHP <= 0)
        {
            EnemyDefeated();
        }
        else
        {
            EnemyAlive();
        }
    }

    /// <summary> 敵がダメージを食らった処理 </summary>
    /// <param name="amount"> プレイヤーの攻撃値 </param>
    public void TakeDamage(float amount)
    {

    }

    public void EnemyAlive()
    {

    }

    public void EnemyDefeated()
    {
        Debug.Log("敵を倒した");
    }
}
