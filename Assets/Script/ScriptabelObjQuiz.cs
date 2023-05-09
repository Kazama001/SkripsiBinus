using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "quizList",menuName ="quizData")]
public class ScriptabelObjQuiz : ScriptableObject
{
    public List<Question> questions;
}
