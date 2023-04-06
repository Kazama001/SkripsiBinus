using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScript : MonoBehaviour
{
    public Player_Stats playerStats;
    public Enemy_Stats enemyStats;
    public string Turn;

    private void Start()
    {
        Turn = "Player";
    }

    public void Player_Correct()
    {
        playerStats.DealDamagePierced(enemyStats.gameObject);
        Turn = "Enemy";
    }

    public void Player_Wrong()
    {
        playerStats.DealDamage(enemyStats.gameObject);
        Turn = "Enemy";
    }

    public void Enemy_Correct()
    {
        enemyStats.DealDamageBlocked(playerStats.gameObject);
        Turn = "Player";
    }

    public void Enemy_Wrong()
    {
        enemyStats.DealDamage(playerStats.gameObject);
        Turn = "Player";
    }

}
