using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool IsCorrect = false;
    public Manager Manager;
    public BattleScript battlescript;

    private void Start()
    {

    }

    public void Answer()
    {
        if (battlescript.Turn == "Player")
        {
            if (IsCorrect)
            {
                battlescript.Player_Correct();
                Manager.Correct();
            }
            else
            {
                battlescript.Player_Wrong();
                Manager.Correct();

            }
        }
        else if (battlescript.Turn == "Enemy")
        {
            if (IsCorrect)
            {
                battlescript.Enemy_Correct();
                Manager.Correct();
            }
            else
            {
                battlescript.Enemy_Wrong();
                Manager.Correct();
            }
        }
    }

}
