using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    public List<QuestionAndAnswer> QnA;
    public GameObject[] Options;
    public int CurrentQuestion;

    public TextMeshProUGUI QuestionTxt;

    private void Start()
    {
        GenerateQuestion();
    }

    void SetAnswer()
    {
        for (int i = 0; i< Options.Length; i++)
        {
            Options[i].GetComponent<AnswerScript>().IsCorrect = false;
            Options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[CurrentQuestion].Answer[i];

            if(QnA[CurrentQuestion].CurrentAnswer == i + 1)
            {
                Options[i].GetComponent<AnswerScript>().IsCorrect = true;
            }
        }
    }

    public void Correct()
    {
        QnA.RemoveAt(CurrentQuestion);
        GenerateQuestion();
    }

    void GenerateQuestion()
    {
        CurrentQuestion = Random.Range(0, QnA.Count);
        QuestionTxt.text = QnA[CurrentQuestion].Question;

        SetAnswer();

    }

}
