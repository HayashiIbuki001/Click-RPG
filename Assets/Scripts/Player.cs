using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [SerializeField] private float maxHP;
    public float MaxHP => maxHP;

    private float currentHP;
    public float CurrentHP => currentHP;

    public float attackDamage;
    [SerializeField] private float attackDamagePreset = 1;

    private void Start()
    {
        currentHP = maxHP;
        attackDamage = attackDamagePreset;
    }

    public void TakeDamage(float amount)
    {
        currentHP -= amount;
        Debug.Log($"player HP : {currentHP}");

        if (currentHP <= 0)
        {
            Defeat(); // Ž€‚ñ‚¾‚çŽÀs
        }
    }

    private void Defeat()
    {
        gameManager.ReStart();
    }

    private void DamageAmount()
    {

    }
}
