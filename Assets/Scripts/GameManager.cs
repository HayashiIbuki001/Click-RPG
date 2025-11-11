using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;

    [Header("PlayerStatus")]
    [SerializeField] private int coins = 0;

    [Header("UI")]
    [SerializeField] private Slider enemyHPBar;
    [SerializeField] private TextMeshProUGUI enemyHPText;
    [SerializeField] private Slider playerHPBar;
    [SerializeField] private TextMeshProUGUI playerHPText;
    [SerializeField] private TextMeshProUGUI coinText;

    private void Start()
    {
        UpdateUI();
        UpdateStatusUI();
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

    public void AddReward(Reward reward)
    {
        coins += reward.coins;
        Debug.Log($"現在所持コイン数 : {coins}");

        UpdateStatusUI();
    }

    /// <summary>
    /// プレイヤーまたは敵がやられたらリスタートする
    /// </summary>
    /// <param name="playerDefeated">true : プレイヤーがやられる / false : 敵がやられる</param>
    public void ReStart(bool playerDefeated)
    {
        player.ResetStatus();
        enemy.ResetStatus();
        UpdateUI();

        if (playerDefeated)
        {
            // プレイヤー側がやられたときのみ実行する
        }
        else
        {
            // 敵側がやられたときのみ実行する
        }
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

    private void UpdateStatusUI()
    {
        coinText.text = $"{coins}coin";
    }
}
