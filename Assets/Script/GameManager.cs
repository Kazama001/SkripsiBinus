using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    //public static GameManager Instance;
    public int Player_Gold;
    public TextMeshProUGUI PlayerGold;
    [SerializeField] public int Char_HP, Char_Atk, Char_Def, Char_Regen, Char_Timer, Char_GoldBonus, Char_Block, Char_Pierce, Char_WeakenEnemy;
    public TextMeshProUGUI HPLv, AtkLv, DefLv, RegenLv, TimerLv, GoldBonusLv, BlockLv, PierceLv, WeakenEnemyLv;
    public TextMeshProUGUI HPCost, AtkCost, DefCost, RegenCost, TimerCost, GoldBonusCost, BlockCost, PierceCost, WeakenEnemyCost;
    [SerializeField] private float costAtk, costDef, costHP, costRegen, costTimer, costGoldBonus, costBlock, costPierce, costWeakenEnemy;
    [SerializeField] private Button AtkUpg, HPUpg, DefUpg, RegenUpg, TimerUpg, GoldBonusUpg, BlockUpg, PierceUpg, WeakenEnemyUpg;
    private void Awake()
    {
        //Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        Player_Gold = PlayerPrefs.GetInt("PlayerGold",0);
        Char_HP = PlayerPrefs.GetInt("CharHP");
        Char_Atk = PlayerPrefs.GetInt("CharAtk");
        Char_Def = PlayerPrefs.GetInt("CharDef");
        Char_Regen = PlayerPrefs.GetInt("CharRegen");
        Char_Timer = PlayerPrefs.GetInt("CharTimer");
        Char_GoldBonus = PlayerPrefs.GetInt("CharGoldBonus");
        Char_Block = PlayerPrefs.GetInt("CharBlock");
        Char_Pierce = PlayerPrefs.GetInt("CharPierce");
        Char_WeakenEnemy = PlayerPrefs.GetInt("CharWeakenEnemy");

        costHP = PlayerPrefs.GetFloat("costHP", 10);
        costAtk = PlayerPrefs.GetFloat("costAtk", 10);
        costDef = PlayerPrefs.GetFloat("costDef", 10);
        costRegen = PlayerPrefs.GetFloat("costRegen", 30);
        costTimer = PlayerPrefs.GetFloat("costTimer", 50);
        costGoldBonus = PlayerPrefs.GetFloat("costGoldBonus", 100);
        costBlock = PlayerPrefs.GetFloat("costBlock", 100);
        costPierce = PlayerPrefs.GetFloat("costPierce", 100);
        costWeakenEnemy = PlayerPrefs.GetFloat("costWeakenEnemy", 300);
    }
    void Update()
    {
        ButtonInteractable();
        TextUpdate();

    }

    public void clearplayerprefs()
    {
        PlayerPrefs.DeleteAll();
    }

    private void TextUpdate()
    {
        PlayerGold.text = Mathf.Floor(Player_Gold).ToString();

        HPLv.text = "Lv. " + Char_HP;
        HPCost.text = Mathf.Floor(costHP).ToString();

        AtkLv.text = "Lv. " + Char_Atk;
        AtkCost.text = Mathf.Floor(costAtk).ToString();

        DefLv.text = "Lv. " + Char_Def;
        DefCost.text = Mathf.Floor(costDef).ToString();

        RegenLv.text = "Lv. " + Char_Regen;
        RegenCost.text = Mathf.Floor(costRegen).ToString();

        TimerLv.text = "Lv. " + Char_Timer;
        TimerCost.text = Mathf.Floor(costTimer).ToString();

        GoldBonusLv.text = "Lv. " + Char_GoldBonus;
        GoldBonusCost.text = Mathf.Floor(costGoldBonus).ToString();

        BlockLv.text = "Lv. " + Char_Block;
        BlockCost.text = Mathf.Floor(costBlock).ToString();

        PierceLv.text = "Lv. " + Char_Pierce;
        PierceCost.text = Mathf.Floor(costPierce).ToString();

        WeakenEnemyLv.text = "Lv. " + Char_WeakenEnemy;
        WeakenEnemyCost.text = Mathf.Floor(costWeakenEnemy).ToString();
    }

    private void ButtonInteractable()
    {
        if (Player_Gold < (int)costAtk)
        {
            AtkUpg.interactable = false;
        }
        else
        {
            AtkUpg.interactable = true;
        }

        if (Player_Gold < (int)costDef)
        {
            DefUpg.interactable = false;
        }
        else
        {
            DefUpg.interactable = true;
        }

        if (Player_Gold < (int)costHP)
        {
            HPUpg.interactable = false;
        }
        else
        {
            HPUpg.interactable = true;
        }

        if (Player_Gold < (int)costRegen)
        {
            RegenUpg.interactable = false;
        }
        else
        {
            RegenUpg.interactable = true;
        }

        if (Player_Gold < (int)costTimer)
        {
            TimerUpg.interactable = false;
        }
        else
        {
            TimerUpg.interactable = true;
        }

        if (Player_Gold < (int)costGoldBonus)
        {
            GoldBonusUpg.interactable = false;
        }
        else
        {
            GoldBonusUpg.interactable = true;
        }

        if (Player_Gold < (int)costBlock)
        {
            BlockUpg.interactable = false;
        }
        else
        {
            BlockUpg.interactable = true;
        }

        if (Player_Gold < (int)costPierce)
        {
            PierceUpg.interactable = false;
        }
        else
        {
            PierceUpg.interactable = true;
        }

        if (Player_Gold < (int)costWeakenEnemy)
        {
            WeakenEnemyUpg.interactable = false;
        }
        else
        {
            GoldBonusUpg.interactable = true;
        }
    }

    public void ChangeScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void HealthPoint(int Amount)
    {
        Amount = Char_HP;
    }
    public void HealthPointUpgrade()
    {
        if (Player_Gold >= (int)costHP)
        {
            Player_Gold = Player_Gold - (int)costHP;
            Char_HP++;
            PlayerPrefs.SetFloat("costHP", costHP);
            PlayerPrefs.SetInt("CharHP", Char_HP);
            PlayerPrefs.SetInt("PlayerGold", Player_Gold);
        }
        costHP *= 1.1f;
    }

    public void AtkPower(int Amount)
    {
        Amount = Char_Atk * 2;
    }
    public void AtkUpgrade()
    { 
        if(Player_Gold >= (int)costAtk)
        {
            Player_Gold = Player_Gold - (int)costAtk;
            Char_Atk++;
            PlayerPrefs.SetFloat("costAtk", costAtk);
            PlayerPrefs.SetInt("CharAtk", Char_Atk);
            PlayerPrefs.SetInt("PlayerGold", Player_Gold);
        }
        costAtk *= 1.1f;
    }

    public void DefPower(int Amount)
    {
        Amount = Char_Def;
    }
    public void DefUpgrade()
    {
        if (Player_Gold >= (int)costDef)
        {
            Player_Gold = Player_Gold - (int)costDef;
            Char_Def++;
            PlayerPrefs.SetFloat("costDef", costDef);
            PlayerPrefs.SetInt("CharDef", Char_Def);
            PlayerPrefs.SetInt("PlayerGold", Player_Gold);
        }
        costDef *= 1.12f;
    }

    public void Regen(int Amount)
    {
        Amount = Char_Regen;
    }
    public void RegenUpgrade()
    {
        if (Player_Gold >= (int)costRegen)
        {
            Player_Gold = Player_Gold - (int)costRegen;
            Char_Regen++;
            PlayerPrefs.SetFloat("costRegen", costRegen);
            PlayerPrefs.SetInt("CharRegen", Char_Regen);
            PlayerPrefs.SetInt("PlayerGold", Player_Gold);
        }
        costRegen *= 1.1f;
    }

    public void Timer(int Amount)
    {
        Amount = 10 + Char_Timer;
    }
    public void TimerUpgrade()
    {
        if (Player_Gold >= (int)costTimer)
        {
            Player_Gold = Player_Gold - (int)costTimer;
            Char_Timer++;
            PlayerPrefs.SetFloat("costTimer", costTimer);
            PlayerPrefs.SetInt("CharTimer", Char_Timer);
            PlayerPrefs.SetInt("PlayerGold", Player_Gold);
        }
        costTimer *= 1.1f;
    }

    public void GetGold(int Amount)
    {
        Player_Gold = Player_Gold + (int)(Amount * (1 + Char_GoldBonus * 0.02f));
        PlayerPrefs.SetInt("PlayerGold", Player_Gold);
    }
    public void GoldUpgrade()
    {
        if (Player_Gold >= (int)costGoldBonus)
        {
            Player_Gold = Player_Gold - (int)costGoldBonus;
            Char_GoldBonus++;
            PlayerPrefs.SetFloat("costGoldBonus", costGoldBonus);
            PlayerPrefs.SetInt("CharGoldBonus", Char_GoldBonus);
            PlayerPrefs.SetInt("PlayerGold", Player_Gold);
        }
        costGoldBonus *= 1.1f;
    }

    public void PiercePower(float Amount)
    {
        Amount = 0.9f - Char_Pierce * 0.01f;
    }
    public void PierceUpgrade()
    {
        if (Player_Gold >= (int)costPierce)
        {
            Player_Gold = Player_Gold - (int)costPierce;
            Char_Pierce++;
            PlayerPrefs.SetFloat("costPierce", costPierce);
            PlayerPrefs.SetInt("CharPierce", Char_Pierce);
            PlayerPrefs.SetInt("PlayerGold", Player_Gold);
        }
        costPierce *= 1.1f;
    }

    public void BlockPower(float Amount)
    {
        Amount = 0.9f - Char_Block * 0.01f;
    }
    public void BlockUpgrade()
    {
        if (Player_Gold >= (int)costBlock)
        {
            Player_Gold = Player_Gold - (int)costBlock;
            Char_Block++;
            PlayerPrefs.SetFloat("costBlock", costBlock);
            PlayerPrefs.SetInt("CharBlock", Char_Block);
            PlayerPrefs.SetInt("PlayerGold", Player_Gold);
        }
        costBlock *= 1.1f;
    }
    
    public void WeakenEnemyPower(float Amount)
    {
        Amount = 0.9f - Char_Block * 0.01f;
    }
    public void WeakenEnemyUpgrade()
    {
        if (Player_Gold >= (int)costWeakenEnemy)
        {
            Player_Gold = Player_Gold - (int)costWeakenEnemy;
            Char_WeakenEnemy++;
            PlayerPrefs.SetFloat("costWeakenEnemy", costWeakenEnemy);
            PlayerPrefs.SetInt("CharWeakenEnemy", Char_WeakenEnemy);
            PlayerPrefs.SetInt("PlayerGold", Player_Gold);
        }
        costWeakenEnemy *= 1.1f;
    }

}

