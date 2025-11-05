using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float maxHP;
    private float currentHP;

    [SerializeField] private float attackDamage;

    private void Start()
    {
        currentHP = maxHP;
    }
}
