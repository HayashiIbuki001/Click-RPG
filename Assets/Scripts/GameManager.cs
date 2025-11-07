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

    public void EnemyAttack()
    {

    }

    private void ReStart()
    {

    }

    private void UpdateUI()
    {
        float ratio = enemy.CurrentHP / enemy.MaxHP;
        enemyHPBar.value = ratio;

        enemyHPText.text = $"{Mathf.RoundToInt(enemy.CurrentHP)} / {Mathf.RoundToInt(enemy.MaxHP)}";
    }
}
