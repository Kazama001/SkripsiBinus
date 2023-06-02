using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleScript : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Animator enemyAnimator, playerAnimator;
    public Player_Stats playerStats;
    public Enemy_Stats enemyStats;
    public string Turn;
    public Player_Movement player_Movement;
    public GameObject[] gameobject;
    public Slider TimerSlider;
    public static BattleScript instance;
    public bool TimerActive;

    [SerializeField] private float AreaTimer;
    private void Start()
    {
        player_Movement = GameObject.Find("Character").GetComponent<Player_Movement>();
        gameManager = GameObject.Find("GameManagers").GetComponent<GameManager>();
        playerStats = GameObject.Find("Character").GetComponent<Player_Stats>();

        TimerSlider.maxValue = 10 + gameManager.Char_Timer - AreaTimer;
        TimerSlider.value = TimerSlider.maxValue;
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
            TimerActive = true;
        }
        if (TimerActive == true)
        {
            TimerSlider.value -= Time.deltaTime;
        }

        if (TimerSlider.value <= 0 && Turn == "Enemy") 
        {
            TimerSlider.value = TimerSlider.maxValue;
            Enemy_Wrong();
        }

        if (TimerSlider.value <= 0 && Turn == "Player")
        {
            TimerSlider.value = TimerSlider.maxValue;
            Player_Wrong();
        }
    }

    public void Player_Correct()
    {
        TimerActive = false;
        playerStats.DealDamagePierced(enemyStats.gameObject);
        Turn = "Enemy";
        gameobject[1].SetActive(false);
        gameobject[2].SetActive(false);
        gameobject[3].SetActive(false);
        gameobject[4].SetActive(false);
        StartCoroutine(EnemyTurn());
        StartCoroutine(PlayerAtkAnimation());
    }

    public void Player_Wrong()
    {
        TimerActive = false;
        playerStats.DealDamage(enemyStats.gameObject);
        Turn = "Enemy";
        gameobject[1].SetActive(false);
        gameobject[2].SetActive(false);
        gameobject[3].SetActive(false);
        gameobject[4].SetActive(false);
        StartCoroutine(EnemyTurn());
        StartCoroutine(PlayerAtkAnimation());
    }

    public void Enemy_Correct()
    {
        
        TimerActive = false;
        enemyStats.DealDamageBlocked(playerStats.gameObject);
        Turn = "Player";
        gameobject[1].SetActive(false);
        gameobject[2].SetActive(false);
        gameobject[3].SetActive(false);
        gameobject[4].SetActive(false);
        if (playerStats.Player_CurrentHP > 0)
        {
            StartCoroutine(PlayerTurn());     
        }
        StartCoroutine(EnemyAtkAnimation());
    }

    public void Enemy_Wrong()
    {
        TimerActive = false;
        enemyStats.DealDamage(playerStats.gameObject);
        Turn = "Player";
        gameobject[1].SetActive(false);
        gameobject[2].SetActive(false);
        gameobject[3].SetActive(false);
        gameobject[4].SetActive(false);
        if (playerStats.Player_CurrentHP > 0)
        {
            StartCoroutine(PlayerTurn()); 
        }
        StartCoroutine(EnemyAtkAnimation());
    }
    IEnumerator PlayerTurn()
    {
        yield return new WaitForSeconds(3.5f);
        gameobject[1].SetActive(true);
        gameobject[2].SetActive(true);
        gameobject[3].SetActive(true);
        TimerSlider.value = TimerSlider.maxValue;
        TimerActive = true;
    }
    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(5);
        gameobject[1].SetActive(true);
        gameobject[2].SetActive(true);
        gameobject[4].SetActive(true);
        TimerSlider.value = TimerSlider.maxValue;
        TimerActive = true;
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
        playerStats.Regen();
        yield return new WaitForSeconds(5);
        gameobject[1].SetActive(false);
        gameobject[2].SetActive(false);
        gameobject[3].SetActive(false);
        gameobject[4].SetActive(false);
        player_Movement.enabled = true;
        player_Movement.playerAnimator.SetBool("IsRunning", true);
        player_Movement.playerAnimator.SetBool("IsIdle", false);
        enemyStats.enabled = false;
        TimerActive = false;
    }

    public void getEnemyStats(Enemy_Stats enemystats)
    {
        enemyStats = enemystats;
    }

    

}
