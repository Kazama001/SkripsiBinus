using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class quizUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private quizManager quizManager;
    [SerializeField] private List<Button> options;
    [SerializeField] private Color correct, wrong, normal;
    private Question question;
    private bool answered;

    void Awake()
    {
        for(int i = 0; i < options.Count; i++)
        {
            Button localBtn = options[i];
            localBtn.onClick.AddListener(() => OnClick(localBtn));
        }

    }

    public void SetQuestion(Question question)
    {
        this.question = question;
        

        questionText.text = question.qustionInfo;   //set question

        //suffle question
        List<string> ansOptions = ShuffleList.ShuffleListItems<string>(question.option);

        //assign btn
        for (int i = 0; i < options.Count; i++)
        {
            options[i].GetComponentInChildren<Text>().text = ansOptions[i];
            options[i].name = ansOptions[i];    //set btn name
            options[i].image.color = normal; //set btn color
        }

        answered = false;
    }

  void OnClick(Button btn)
    {
        if (!answered)
        {
            answered = true;
            bool val = quizManager.Answer(btn.name);

            if (val)
            {
                btn.image.color = correct;
            }
            else
            {
                btn.image.color = wrong;
            }
        }
    }
}
