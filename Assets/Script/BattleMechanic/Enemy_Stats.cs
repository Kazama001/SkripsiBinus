using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Enemy_Stats : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    int EnemyHPdown, EnemyAtkDown, EnemyDefDown;
    public int Enemy_MaxHP, Enemy_CurrentHP, Enemy_Atk, Enemy_Def, Enemy_GoldValue;
    bool isDead;
    [SerializeField] private Slider Enemy_HPSlider;
    [SerializeField] private TextMeshProUGUI Text_HP,Text_Atk,Text_Def, Text_Name;

    public static Enemy_Stats instance;

    private void Start()
    {
        Enemy_MaxHP = (int)(Enemy_MaxHP * (1 - gameManager.Char_WeakenEnemy * 0.01f));
        Enemy_CurrentHP = Enemy_MaxHP;
        Enemy_Atk = (int)(Enemy_Atk * (1 - gameManager.Char_WeakenEnemy * 0.01f));
        Enemy_Def = (int)(Enemy_Def * (1 - gameManager.Char_WeakenEnemy * 0.01f));
        Enemy_GoldValue = (int)(Enemy_GoldValue * (1 + gameManager.Char_GoldBonus * 0.05f));
    }

    private void Awake()
    {
        gameManager = GameObject.Find("GameManagers").GetComponent<GameManager>();
        Enemy_HPSlider = GameObject.Find("Stats_Enemy").transform.GetChild(0).GetComponent<Slider>();
        Text_Atk = GameObject.Find("Stats_Enemy").transform.GetChild(1).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        Text_Def = GameObject.Find("Stats_Enemy").transform.GetChild(2).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        Text_HP = GameObject.Find("Stats_Enemy").transform.GetChild(0).transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        Text_Name = GameObject.Find("Stats_Enemy").transform.GetChild(3).GetComponent<TextMeshProUGUI>();

        instance = this;
    }

    private void Update()
    {
        status();
        if (Enemy_CurrentHP <= 0 && !isDead)
        {
            StartCoroutine(BattleScript.instance.enemydead());
            Enemy_CurrentHP = 0;
            isDead = true;
            gameManager.GetGold(Enemy_GoldValue);
        }
    }

    public void status()
    {
        
        Text_HP.text = Enemy_CurrentHP.ToString() + "/" + Enemy_MaxHP.ToString();
        Enemy_HPSlider.value = (float)Enemy_CurrentHP / (float)Enemy_MaxHP;

        //Enemy_Atk = (int)(Enemy_BaseAtk-EnemyAtkDown);
        Text_Atk.text = Enemy_Atk.ToString();

        //Enemy_Def = (int)(Enemy_BaseDef-EnemyDefDown);
        Text_Def.text = Enemy_Def.ToString();
    }

    public void TakeDamage(int Amount)
    {
        Enemy_CurrentHP -= Amount - Enemy_Def;
    }
    public void TakeDamagePierced(int Amount, float pierce)
    {
        Enemy_CurrentHP -= (int)((Amount - Enemy_Def) * (1.1 + pierce));
    }
    public void DealDamage(GameObject target)
    {
        var stats = target.GetComponent<Player_Stats>();
        if (stats != null)
        {
            stats.TakeDamage(Enemy_Atk);
        }
    }
    public void DealDamageBlocked(GameObject target)
    {
        var stats = target.GetComponent<Player_Stats>();
        if (stats != null)
        {
            stats.TakeDamageBlocked(Enemy_Atk);
        }
    }

    
}
