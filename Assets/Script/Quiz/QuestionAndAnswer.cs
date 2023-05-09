[System.Serializable]
public class QuestionAndAnswer
{
    public string Question;
    public string[] Answer;
    public int CurrentAnswer;
}

[System.Serializable]
public class AnswerOption
{
    public string optionA;
    public string optionB;
    public string optionC;
    public string optionD;
}

[System.Serializable]
public class QuestionAndAnswer2
{
    public string Question;
    public AnswerOption[] Answer;
    public int CurrentAnswer;
}

[System.Serializable]
public class QuestionAndAnswerList
{
    public QuestionAndAnswer2[] QnAList;
}