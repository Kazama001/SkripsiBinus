using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScript : MonoBehaviour
{
    [SerializeField] private Animator enemyAnimator, playerAnimator;
    public Player_Stats playerStats;
    public Enemy_Stats enemyStats;
    public string Turn;
    public Player_Movement player_Movement;
    public GameObject[] gameobject;

    public static BattleScript instance;

    private void Start()
    {
        instance = this;
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
            enemyAnimator = player_Movement.enemyAnimator;
            playerAnimator = player_Movement.playerAnimator;
            gameobject[1].SetActive(true);
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
        StartCoroutine(PlayerAtkAnimation());
    }

    public void Player_Wrong()
    {
        playerStats.DealDamage(enemyStats.gameObject);
        Turn = "Enemy";
        gameobject[2].SetActive(false);
        gameobject[3].SetActive(false);
        gameobject[4].SetActive(false);
        StartCoroutine(EnemyTurn());
        StartCoroutine(PlayerAtkAnimation());
    }

    public void Enemy_Correct()
    {
        enemyStats.DealDamageBlocked(playerStats.gameObject);
        Turn = "Player";
        gameobject[2].SetActive(false);
        gameobject[3].SetActive(false);
        gameobject[4].SetActive(false);
        StartCoroutine(PlayerTurn());
        StartCoroutine(EnemyAtkAnimation());
    }

    public void Enemy_Wrong()
    {
        enemyStats.DealDamage(playerStats.gameObject);
        Turn = "Player";
        gameobject[2].SetActive(false);
        gameobject[3].SetActive(false);
        gameobject[4].SetActive(false);
        StartCoroutine(PlayerTurn());
        StartCoroutine(EnemyAtkAnimation());
    }
    IEnumerator PlayerTurn()
    {
        yield return new WaitForSeconds(3.5f);
        gameobject[2].SetActive(true);
        gameobject[3].SetActive(true);
    }
    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(5);
        gameobject[2].SetActive(true);
        gameobject[4].SetActive(true);
    }

    IEnumerator EnemyAtkAnimation ()
    {
        enemyAnimator.SetTrigger("IsAttacking");
        yield return new WaitForSeconds(1);
        playerAnimator.SetTrigger("IsAttacked");
    }

    IEnumerator PlayerAtkAnimation()
    {
        playerAnimator.SetTrigger("IsAttacking");
        yield return new WaitForSeconds(1);
        enemyAnimator.SetTrigger("IsAttacked");
    }
    public IEnumerator enemydead()
    {
        Turn = "Player";
        yield return new WaitForSeconds(5);
        gameobject[1].SetActive(false);
        gameobject[2].SetActive(false);
        gameobject[3].SetActive(false);
        gameobject[4].SetActive(false);
        player_Movement.enabled = true;
        player_Movement.playerAnimator.SetBool("IsRunning", true);
        player_Movement.playerAnimator.SetBool("IsIdle", false);
        enemyStats.enabled = false;
    }

    public void getEnemyStats(Enemy_Stats enemystats)
    {
        enemyStats = enemystats;
        print(enemystats.gameObject.name);
    }

}
