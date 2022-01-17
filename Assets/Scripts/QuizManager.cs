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
    public int CurrentQuestion;
    public int NumCorrectAnswers { get; private set; }
    public int NumWrongAnswers { get; private set; }

    private int _numberHiddenButtons = 2;

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        NumCorrectAnswers = 0;
        NumWrongAnswers = 0;
        RandomQuestion();
    }

    #endregion


    #region Public methods
    public void BtnPressed(int buttonKey)
    {
        if (QuestionConfigs[CurrentQuestion].Answers[buttonKey].IsCorrect)
        {
            NumCorrectAnswers++;
            Debug.Log("Ответ правильный " + NumCorrectAnswers);
            Options[buttonKey].color = Color.green;
            QuestionConfigs.RemoveAt(CurrentQuestion);
            RandomQuestion();
        }
        else
        {
            NumWrongAnswers++;
            Debug.Log("Ответ НЕправильный " + NumWrongAnswers);
            Options[buttonKey].color = Color.red;
            QuestionConfigs.RemoveAt(CurrentQuestion);
            RandomQuestion();
        }
    }

    public void HideWrongButtons()
    {
        for (int i = 0; i < Buttons.Length; i++)
        {
            if (_numberHiddenButtons > 0)
            {
                if (QuestionConfigs[CurrentQuestion].Answers[i].IsCorrect)
                {
                    continue;
                }

                Buttons[i].SetActive(false);

                _numberHiddenButtons--;
            }
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
            Options[i].text = QuestionConfigs[CurrentQuestion].Answers[i].AnswerText;
        }
    }

    private void RandomQuestion()
    {
        int _totalQuestions = QuestionConfigs.Count;
        if (_totalQuestions > 0)
        {
            CurrentQuestion = Random.Range(0, _totalQuestions);
            QuestionLabel.text = QuestionConfigs[CurrentQuestion].ContentQuestion;
            ImageLabel.sprite = QuestionConfigs[CurrentQuestion].Image;
            SetAnswers();
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }

    #endregion
}