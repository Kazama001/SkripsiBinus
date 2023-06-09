using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Enemy_Stats : MonoBehaviour
{
    [SerializeField] private int Enemy_MaxHP, Enemy_CurrentHP, Enemy_Atk, Enemy_Def;
    [SerializeField] private int Enemy_BaseHP, Enemy_BaseAtk, Enemy_BaseDef;
    [SerializeField] private float Enemy_Area;
    [SerializeField] private float Enemy_Stage;
    public Slider Enemy_HPSlider;
    public TextMeshProUGUI Text_HP;
    public TextMeshProUGUI Text_Atk;
    public TextMeshProUGUI Text_Def;

    public static Enemy_Stats instance;
    private void Start()
    {
        instance = this;
        Enemy_BaseHP = 10;
        Enemy_BaseAtk = 5;
        Enemy_BaseDef = 2;
        
        Enemy_Area = 1.1f;
        Enemy_Stage = 1.2f;
        status();
        
        Enemy_CurrentHP = 15;
        /*
        Enemy_HP   = 100   + Enemy_HP_Shop    * 2;
        Enemy_Atk  = 10    + Enemy_Atk_Shop   * 2;
        Enemy_Def  = 5     + Enemy_Def_Shop   * 2;
        */
    }

    private void Update()
    {
        status();
    }
    public void status()
    {
        Enemy_MaxHP = (int)(Enemy_BaseHP * Enemy_Area * Enemy_Stage);
        Text_HP.text = Enemy_CurrentHP.ToString() + "/" + Enemy_MaxHP.ToString();
        Enemy_HPSlider.value = (float)Enemy_CurrentHP / (float)Enemy_MaxHP;

        Enemy_Atk = (int)(Enemy_BaseAtk * Enemy_Area * Enemy_Stage);
        Text_Atk.text = Enemy_Atk.ToString();

        Enemy_Def = (int)(Enemy_BaseDef * Enemy_Area * Enemy_Stage);
        Text_Def.text = Enemy_Def.ToString();
    }

    public void DealDamage(int Enemy_Atk)
    {

    }

}
