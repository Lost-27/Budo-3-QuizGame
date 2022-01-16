using System;
using UnityEngine;

public class CorrectAndWrongAnswersData : MonoBehaviour
{
    private static CorrectAndWrongAnswersData _instance;
    private QuizManager _quizManager;

    public int CorrectAnswers { get; private set; }
    public int WrongAnswers { get; private set; }

    private void Awake()
    {
        DemoSingleton();
    }

    private void Start()
    {
        _quizManager = FindObjectOfType<QuizManager>();
    }

    private void Update()
    {
        CorrectAnswers = _quizManager.NumCorrectAnswers;
        WrongAnswers = _quizManager.NumWrongAnswers;
    }
    
    private void DemoSingleton()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
}