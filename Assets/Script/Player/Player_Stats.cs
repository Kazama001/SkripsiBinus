using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player_Stats : MonoBehaviour
{
    
    public int Player_MaxHP, Player_CurrentHP, Player_MP, Player_Atk, Player_Def;
    [SerializeField] private int Player_HP_Shop, Player_Atk_Shop, Player_Def_Shop;
    public Slider Player_HPSlider, Player_MPSlider;
    public TextMeshProUGUI Text_HP;
    public TextMeshProUGUI Text_Atk;
    public TextMeshProUGUI Text_Def;
    
    private void Start()
    {
        status();
        Player_CurrentHP = Player_MaxHP;
        Player_MP = 3;
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
        Player_MaxHP = 100 + Player_HP_Shop * 2;
        Text_HP.text = Player_CurrentHP.ToString() + "/" + Player_MaxHP.ToString();
        Player_HPSlider.value = (float)Player_CurrentHP / (float)Player_MaxHP;
        Player_MPSlider.value = Player_MP;

        Player_Atk = 10 + Player_Atk_Shop * 2;
        Text_Atk.text = Player_Atk.ToString();

        Player_Def = 5 + Player_Def_Shop * 1;
        Text_Def.text = Player_Def.ToString();
    }


    public void TakeDamage(int Amount)
    {
        Player_CurrentHP -= Amount - Player_Def;
    }
    public void TakeDamageBlocked(int Amount)
    {
        Player_CurrentHP -= (int)((Amount - Player_Def) * 0.5);
    }

    public void DealDamage(GameObject target)
    {
        var stats = target.GetComponent<Enemy_Stats>();
        if (stats != null)
        {
            stats.TakeDamage(Player_Atk);
        }
    }

    public void DealDamagePierced(GameObject target)
    {
        var stats = target.GetComponent<Enemy_Stats>();
        if (stats != null)
        {
            stats.TakeDamagePierced(Player_Atk);
        }
    }
}
