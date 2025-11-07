using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float maxHP;
    private float currentHP;

    public float attackDamage;
    [SerializeField] private float attackDamagePreset = 1;

    private void Start()
    {
        currentHP = maxHP;
        attackDamage = attackDamagePreset;
    }

    private void DamageAmount()
    {

    }
}
