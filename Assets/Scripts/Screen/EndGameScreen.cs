using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGameScreen : MonoBehaviour
{
    #region Variables

    public Button RestartButton;
    public Button QuitButton;

    public TextMeshProUGUI NumCorrectAnswersLabel;
    public TextMeshProUGUI NumWrongAnswersLabel;

    private CorrectAndWrongAnswersData _correctAndWrongAnswers;
    private SceneHelper _sceneHelper;

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        RestartButton.onClick.AddListener(RestartButtonClicked);
        QuitButton.onClick.AddListener(QuitButtonClicked);

        _correctAndWrongAnswers = FindObjectOfType<CorrectAndWrongAnswersData>();
        _sceneHelper = FindObjectOfType<SceneHelper>();

        NumCorrectAnswersLabel.text = Convert.ToString(_correctAndWrongAnswers.CorrectAnswers);
        NumWrongAnswersLabel.text = Convert.ToString(_correctAndWrongAnswers.WrongAnswers);
    }

    #endregion


    #region Private methods

    private void QuitButtonClicked()
    {
        _sceneHelper.Quit();
    }

    private void RestartButtonClicked()
    {
        _sceneHelper.LoadScene(0);
    }

    #endregion
}