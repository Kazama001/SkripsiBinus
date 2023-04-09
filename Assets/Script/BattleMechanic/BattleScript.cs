using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScript : MonoBehaviour
{

    public Player_Stats playerStats;
    public Enemy_Stats enemyStats;
    public string Turn;
    public Player_Movement player_Movement;
    public GameObject[] gameobject;

    private void Start()
    {
        Turn = "Player";
        gameobject[0].SetActive(false);
        gameobject[1].SetActive(false);
        gameobject[2].SetActive(false);
        gameobject[3].SetActive(false);
        gameobject[4].SetActive(false);
    }

    void Update()
    {
        if (player_Movement.battleStart == true)
        {
            gameobject[1].SetActive(true);
        }
        if (player_Movement.battleStart == true && Turn == "Player")
        {
            gameobject[2].SetActive(true);
            gameobject[3].SetActive(true);
            player_Movement.battleStart = false;
        }

    }

    public void Player_Correct()
    {
        playerStats.DealDamagePierced(enemyStats.gameObject);
        Turn = "Enemy";
        gameobject[2].SetActive(false);
        gameobject[3].SetActive(false);
        gameobject[4].SetActive(false);
        StartCoroutine(EnemyTurn());
    }

    public void Player_Wrong()
    {
        playerStats.DealDamage(enemyStats.gameObject);
        Turn = "Enemy";
        gameobject[2].SetActive(false);
        gameobject[3].SetActive(false);
        gameobject[4].SetActive(false);
        StartCoroutine(EnemyTurn());
    }

    public void Enemy_Correct()
    {
        enemyStats.DealDamageBlocked(playerStats.gameObject);
        Turn = "Player";
        gameobject[2].SetActive(false);
        gameobject[3].SetActive(false);
        gameobject[4].SetActive(false);
        StartCoroutine(PlayerTurn());
    }

    public void Enemy_Wrong()
    {
        enemyStats.DealDamage(playerStats.gameObject);
        Turn = "Player";
        gameobject[2].SetActive(false);
        gameobject[3].SetActive(false);
        gameobject[4].SetActive(false);
        StartCoroutine(PlayerTurn());
    }
    IEnumerator PlayerTurn()
    {
        yield return new WaitForSeconds(5);
        gameobject[2].SetActive(true);
        gameobject[3].SetActive(true);
    }
    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(5);
        gameobject[2].SetActive(true);
        gameobject[4].SetActive(true);
    }

    public void UIShow()
    {
        
    }
}
