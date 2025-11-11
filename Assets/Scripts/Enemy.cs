using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Reward reward = new Reward(10);
     
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
        if (!isDefeated)
        {
            // ‚¢‚«‚Ä‚é
            Attack();
        }
    }

    /// <summary> “G‚ªƒ_ƒ[ƒW‚ğH‚ç‚Á‚½ˆ— </summary>
    /// <param name="amount"> ƒvƒŒƒCƒ„[‚ÌUŒ‚’l </param>
    public void TakeDamage(float amount)
    {
        currentHP -= amount;
        if (currentHP <= 0) 
        {
            currentHP = 0;

            if (!isDefeated)
            {
                EnemyDefeated();
            }
        };
        //Debug.Log($"Enemy HP : {currentHP}");
    }

    public void Attack()
    {     
        attackTimer += Time.deltaTime;
        if (attackTimer >= enemyAttackInterval)
        {
            attackTimer = 0f;
            gameManager.EnemyAttack(attackDamage); // UŒ‚
        }
    }

    public Reward GetReward()
    {
        return reward;
    }

    public void EnemyDefeated()
    {
        isDefeated = true;

        gameManager.AddReward(GetReward());

        gameManager.ReStart(false);
        Debug.Log("“G‚ğ“|‚µ‚½");
    }

    public void ResetStatus()
    {
        currentHP = MaxHP;
        attackTimer = 0f;
        isDefeated= false;
    }
}
