using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player_Stats : MonoBehaviour
{
    [SerializeField] private int Player_MaxHP, Player_CurrentHP, Player_MP, Player_Atk,  Player_Def;
    [SerializeField] private int Player_HP_Shop, Player_Atk_Shop, Player_Def_Shop;
    public Slider Player_HPSlider, Player_MPSlider;
    public TextMeshProUGUI Text_HP;
    public TextMeshProUGUI Text_Atk;
    public TextMeshProUGUI Text_Def;
    
    private void Start()
    {
        status();
        Player_CurrentHP = 35;
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
    public void RecieveDamage()
    {
        
    }
}
