using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
     
    [SerializeField] private float maxHP;
    public float MaxHP => maxHP;

    private float currentHP;
    public float CurrentHP => currentHP;

    [SerializeField] private float attackDamage;
    [SerializeField] private float enemyAttackInterval = 2f;
    private float attackTimer = 0f;

    public bool isDefeated;

    private void Start()
    {
        currentHP = maxHP;
        isDefeated = false;
    }

    private void Update()
    {
        IsActive();
    }

    private void IsActive()
    {
        if (currentHP <= 0 && !isDefeated)
        {
            // しんでる
            EnemyDefeated(); // これは一度きり実行
        }
        else
        {
            // いきてる
            Attack();
        }
    }

    /// <summary> 敵がダメージを食らった処理 </summary>
    /// <param name="amount"> プレイヤーの攻撃値 </param>
    public void TakeDamage(float amount)
    {
        currentHP -= amount;
        if (currentHP <= 0) { currentHP = 0; };
        //Debug.Log($"Enemy HP : {currentHP}");
    }

    public void Attack()
    {     
        attackTimer += Time.deltaTime;
        if (attackTimer >= enemyAttackInterval)
        {
            attackTimer = 0f;
            gameManager.EnemyAttack(attackDamage); // 攻撃
        }
    }

    public void EnemyDefeated()
    {
        isDefeated = true;
        Debug.Log("敵を倒した");
    }
}
