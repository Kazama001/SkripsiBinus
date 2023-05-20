using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player_Stats : MonoBehaviour
{
    public int regenValue;
    [SerializeField] private GameManager gameManager;
    public int Player_MaxHP, Player_CurrentHP, Player_MP, Player_Atk, Player_Def, Player_Regen;
    [SerializeField] private int Player_HP_Shop, Player_Atk_Shop, Player_Def_Shop;
    [SerializeField] private float Player_Pierce, Player_Block;
    public Slider Player_HPSlider, Player_MPSlider;
    public TextMeshProUGUI Text_HP, Text_Def, Text_Atk, Text_Gold;
    private void Start()
    {
        gameManager = GameObject.Find("GameManagers").GetComponent<GameManager>();
        //GameManager.Instance.HealthPoint(Player_HP_Shop);
        //GameManager.Instance.AtkPower(Player_Atk_Shop);
        //GameManager.Instance.DefPower(Player_Def_Shop);
        Player_HP_Shop = gameManager.Char_HP * 5;
        Player_MaxHP = 100 + Player_HP_Shop;
        Player_CurrentHP = Player_MaxHP;

        Player_Regen = gameManager.Char_Regen * 5;

        Player_Atk_Shop = gameManager.Char_Atk * 2;
        Player_Atk = 10 + Player_Atk_Shop;

        Player_Def_Shop = gameManager.Char_Def;
        Player_Def = 5 + Player_Def_Shop;

        status();
        
        /*
        Player_HP   = 100   + Player_HP_Shop    * 2;
        Player_Atk  = 10    + Player_Atk_Shop   * 2;
        Player_Def  = 5     + Player_Def_Shop   * 2;
        */
    }



    private void Update()
    {
        status();
    }

    public void status()
    {
        Text_HP.text = Player_CurrentHP.ToString() + "/" + Player_MaxHP.ToString();
        Player_HPSlider.value = (float)Player_CurrentHP / (float)Player_MaxHP;
        Text_Gold.text = gameManager.Player_Gold.ToString();
        Text_Atk.text = Player_Atk.ToString();
        Text_Def.text = Player_Def.ToString();
    }

    public void TakeDamage(int Amount)
    {
        Player_CurrentHP -= Amount - Player_Def;
    }
    public void TakeDamageBlocked(int Amount)
    {
        Player_CurrentHP -= (int)((Amount - Player_Def) * (Player_Block));
    }

    public void DealDamage(GameObject target)
    {
        var stats = target.GetComponent<Enemy_Stats>();
        if (stats != null)
        {
            stats.TakeDamage(Player_Atk);
        }
    }

    public void Regen()
    {
        Player_CurrentHP += Player_Regen;
        //gameManager.RegenHP(Player_CurrentHP);
        if (Player_CurrentHP > Player_MaxHP)
        {
            Player_CurrentHP = Player_MaxHP;
        }
    }

    public void DealDamagePierced(GameObject target)
    {
        var stats = target.GetComponent<Enemy_Stats>();
        if (stats != null)
        {
            stats.TakeDamagePierced(Player_Atk,Player_Pierce);
        }
    }
}
