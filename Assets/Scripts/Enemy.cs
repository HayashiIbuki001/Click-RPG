using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float maxHP;
    public float MaxHP => maxHP;

    private float currentHP;
    public float CurrentHP => currentHP;

    [SerializeField] private float attackDamage;

    public bool isDefeated;

    private void Start()
    {
        currentHP = maxHP;
        isDefeated = false;
    }

    private void Update()
    {
        if (currentHP <= 0 && !isDefeated)
        {
            EnemyDefeated();
        }
        else
        {
            EnemyAlive();
        }
    }

    /// <summary> “G‚ªƒ_ƒ[ƒW‚ğH‚ç‚Á‚½ˆ— </summary>
    /// <param name="amount"> ƒvƒŒƒCƒ„[‚ÌUŒ‚’l </param>
    public void TakeDamage(float amount)
    {
        currentHP -= amount;
        if (currentHP <= 0) { currentHP = 0; };
        Debug.Log($"Enemy HP : {currentHP}");
    }

    public void EnemyAlive()
    {
        // UŒ‚ˆ—‚Æ‚©
    }

    public void EnemyDefeated()
    {
        isDefeated = true;
        Debug.Log("“G‚ğ“|‚µ‚½");
    }
}
