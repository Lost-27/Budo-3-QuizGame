using System;
using TMPro;
using UnityEngine;

public class EndGameScreen : MonoBehaviour
{
    public TextMeshProUGUI NumCorrectAnswersLabel;
    public TextMeshProUGUI NumWrongAnswersLabel;
    
    private CorrectAndWrongAnswersData _correctAndWrongAnswers;
    // Start is called before the first frame update
    private void Start()
    {
        _correctAndWrongAnswers = FindObjectOfType<CorrectAndWrongAnswersData>();
        NumCorrectAnswersLabel.text = Convert.ToString(_correctAndWrongAnswers.CorrectAnswers);
        NumWrongAnswersLabel.text = Convert.ToString(_correctAndWrongAnswers.WrongAnswers);
    }

    
}
