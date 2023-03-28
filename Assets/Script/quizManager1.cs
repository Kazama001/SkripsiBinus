using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class quizManager : MonoBehaviour
{
    
    [SerializeField] private quizUI quizUI;
    [SerializeField]
    private List<Question> questions;
    private Question selectedQuetion = new Question();
    [SerializeField] private float maxHealt;
    [SerializeField] float currentHealt;
    [SerializeField] GameObject quizPanel;
   


    public void Start()
    {
        StartCoroutine(StartingGame());
    }

    void selectQuestion()
    {
        int val = Random.Range(0, questions.Count);
        selectedQuetion = questions[val];
        quizUI.SetQuestion(selectedQuetion);
        questions.RemoveAt(val);
        if(questions.Count <= 0)
        {
            Debug.Log("this");
        }
    }

    public bool Answer(string answered)
    {
        bool correctAns = false;
        if (answered == selectedQuetion.correctAns)
        {
            
            correctAns = true;
            currentHealt -= 2000;
            Debug.Log(currentHealt);
            
        }
        else
        {
            correctAns = false;
           
        }

        Invoke("selectQuestion",0.2f);

        return correctAns;
    }
    IEnumerator StartingGame()
    {
        yield return new WaitForSeconds(3f);
        quizPanel.SetActive(true);
        selectQuestion();
        currentHealt = maxHealt;
    }
}



[System.Serializable]
public class Question
{
    public string qustionInfo;
    public List<string> option;
    public string correctAns;
    public QuestionType questionType;
}

[System.Serializable]
public enum QuestionType
{
    Text
}