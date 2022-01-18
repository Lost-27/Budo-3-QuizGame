using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    #region Variables

    public List<QuestionConfig> QuestionConfigs;
    public TextMeshProUGUI QuestionLabel;
    public Image ImageLabel;
    public TextMeshProUGUI[] Options;
    public GameObject[] Buttons;

    private QuestionConfig _currentQuestionConfigs;
    private int _numberHiddenButtons = 2;
    private int _currentIndex;

    #endregion


    #region Properties

    public int NumCorrectAnswers { get; private set; }
    public int NumWrongAnswers { get; private set; }

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        NumCorrectAnswers = 0;
        NumWrongAnswers = 0;

        GetRandomQuestion();
    }

    #endregion


    #region Public methods

    public void BtnPressed(int buttonKey)
    {
        if (_currentQuestionConfigs.Answers[buttonKey].IsCorrect)
        {
            NumCorrectAnswers++;
            Debug.Log("Ответ правильный " + NumCorrectAnswers);
            Options[buttonKey].color = Color.green;
        }
        else
        {
            NumWrongAnswers++;
            Debug.Log("Ответ НЕправильный " + NumWrongAnswers);
            Options[buttonKey].color = Color.red;
        }

        QuestionConfigs.RemoveAt(_currentIndex);
        GetRandomQuestion();
    }

    public void HideWrongButtons()
    {
        for (int i = 0; i < Buttons.Length; i++)
        {
            if (_numberHiddenButtons <= 0) 
                continue;
            if (_currentQuestionConfigs.Answers[i].IsCorrect)
            {
                continue;
            }

            Buttons[i].SetActive(false);

            _numberHiddenButtons--;
        }
    }

    public void ShowAllButtons()
    {
        for (int i = 0; i < Buttons.Length; i++)
        {
            Buttons[i].SetActive(true);
            _numberHiddenButtons = 2;
        }
    }

    #endregion


    #region Private methods

    private void SetAnswers()
    {
        for (int i = 0; i < Options.Length; i++)
        {
            Options[i].color = Color.black;
            Options[i].text = _currentQuestionConfigs.Answers[i].AnswerText;
        }
    }

    private void GetRandomQuestion()
    {
        int totalQuestions = QuestionConfigs.Count;
        if (totalQuestions > 0)
        {
            _currentIndex = Random.Range(0, totalQuestions);
            _currentQuestionConfigs = QuestionConfigs[_currentIndex];
            QuestionLabel.text = _currentQuestionConfigs.ContentQuestion;
            ImageLabel.sprite = _currentQuestionConfigs.ImageQuestion;
            SetAnswers();
        }
        else
        {
            CorrectAndWrongAnswersData.Instance.CorrectAnswers = NumCorrectAnswers;
            CorrectAndWrongAnswersData.Instance.WrongAnswers = NumWrongAnswers;
            SceneManager.LoadScene(2);
        }
    }

    #endregion
}