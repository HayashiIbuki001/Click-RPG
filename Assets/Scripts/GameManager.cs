using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;

    [Header("UI")]
    [SerializeField] private Slider enemyHPBar;
    [SerializeField] private TextMeshProUGUI enemyHPText;
    [SerializeField] private Slider playerHPBar;
    [SerializeField] private TextMeshProUGUI playerHPText;

    private void Start()
    {
        UpdateUI();
    }

    public void PlayerAttack()
    {
        if (!enemy.isDefeated)
        {
            enemy.TakeDamage(player.attackDamage);
            UpdateUI();
        }
    }

    public void EnemyAttack(float damage)
    {
        player.TakeDamage(damage);
        UpdateUI();
    }

    public void ReStart()
    {
        
    }

    private void UpdateUI()
    {
        float enemyRatio = enemy.CurrentHP / enemy.MaxHP;
        enemyHPBar.value = enemyRatio;
        enemyHPText.text = $"{Mathf.RoundToInt(enemy.CurrentHP)} / {Mathf.RoundToInt(enemy.MaxHP)}";

        float playerRatio = player.CurrentHP / player.MaxHP;
        playerHPBar.value = playerRatio;
        playerHPText.text = $"{Mathf.RoundToInt(player.CurrentHP)} / {Mathf.RoundToInt(player.MaxHP)}";
    }
}
