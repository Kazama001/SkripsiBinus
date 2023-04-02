using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool IsCorrect = false;
    public Manager Manager;
    public Player_Stats player_Stats;

    public void Answer()
    {
        if (IsCorrect)
        {
            Debug.Log("Benar");
            Manager.Correct();
        }
        else
        {
            Debug.Log("Salah");
            Manager.Correct();
        }
    }

}
