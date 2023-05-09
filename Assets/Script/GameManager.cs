using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    //public static GameManager Instance;
    public Animator UpgradeAnimator;
    public int Player_Gold;
    [SerializeField] public int Char_HP, Char_Atk, Char_Def, Char_Regen, Char_Timer;
    [SerializeField] private float Char_Block, Char_Pierce, Char_GoldBonus;
    public TextMeshProUGUI HPLv, AtkLv, DefLv, RegenLv, TimerLv, GoldLv;
    public TextMeshProUGUI HpCost, AtkCost, DefCost, RegenCost, TimerCost, GoldCost;

    private void Awake()
    {
        //Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        Char_HP = PlayerPrefs.GetInt("CharHP");
        Char_Atk = PlayerPrefs.GetInt("CharAtk");
        Char_Def = PlayerPrefs.GetInt("CharDef");
        Char_Regen = PlayerPrefs.GetInt("CharRegen");
        Char_Timer = PlayerPrefs.GetInt("CharTimer");
        Char_Block = PlayerPrefs.GetFloat("CharBlock");
        Char_Pierce = PlayerPrefs.GetFloat("CharPierce");
        Char_GoldBonus = PlayerPrefs.GetFloat("CharGold");
    }

    void Update()
    {
        HPLv.text = "Lv. " + Char_HP;
        //HpCost.text = 
        AtkLv.text = "Lv. " + Char_Atk;
        //AtkCost.text = 
        DefLv.text = "Lv. " + Char_Def;
        //DefCost.text = 
        RegenLv.text = "Lv. " + Char_Regen;
        //RegenCost.text = 
        TimerLv.text = "Lv. " + Char_Timer;
        //TimerCost.text = 
        GoldLv.text = "Lv. " + Char_GoldBonus;
        //GoldCost.text = 
    }

    public void clearplayerprefs()
    {
        PlayerPrefs.DeleteAll();
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
        Char_HP++;
        PlayerPrefs.SetInt("CharHP", Char_HP);
    }

    public void AtkPower(int Amount)
    {
        Amount = Char_Atk * 2;
    }
    public void AtkUpgrade()
    {
        Char_Atk++;
        PlayerPrefs.SetInt("CharAtk", Char_Atk);
    }

    public void DefPower(int Amount)
    {
        Amount = Char_Def;
    }
    public void DefUpgrade()
    {
        Char_Def++;
        PlayerPrefs.SetInt("CharDef", Char_Def);
    }

    public void Regen(int Amount)
    {
        Amount = Char_Regen;
    }
    public void RegenUpgrade()
    {
        Char_Regen++;
        PlayerPrefs.SetInt("CharRegen", Char_Regen);
    }

    public void Timer(int Amount)
    {
        Amount = 10 + Char_Timer;
    }
    public void TimerUpgrade()
    {
        Char_Timer++;
        PlayerPrefs.SetInt("CharTimer", Char_Timer);
    }

    public void PiercePower(float Amount)
    {
        Amount = 0.9f - Char_Pierce * 0.01f;
    }
    public void PierceUpgrade()
    {
        Char_Pierce++;
        PlayerPrefs.SetFloat("CharPierce", Char_Pierce);
    }

    public void BlockPower(float Amount)
    {
        Amount = 0.9f - Char_Block * 0.01f;
    }
    public void BlockUpgrade()
    {
        Char_Block++;
        PlayerPrefs.SetFloat("CharBlock", Char_Block);
    }

    public void GoldBonus(float Amount)
    {
        Amount = 1 + 0.2f * Char_GoldBonus;
    }
    public void GoldUpgrade()
    {
        Char_GoldBonus++;
        PlayerPrefs.SetFloat("CharGold", Char_GoldBonus);
    }

    public void ToT1()
    {
        UpgradeAnimator.SetTrigger("ToT1");
    }
    public void ToT2()
    {
        UpgradeAnimator.SetTrigger("ToT2");
    }
}

