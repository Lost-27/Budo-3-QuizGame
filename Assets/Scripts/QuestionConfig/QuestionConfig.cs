using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(QuestionConfig), menuName = "Configs/Question")]
public class QuestionConfig : ScriptableObject
{
    #region Variables

    [TextArea(6, 10)] 
    public string ContentQuestion;
    
    [ShowAssetPreview()]
    public Sprite ImageQuestion;
    
    public AnswerData[] Answers;

    #endregion
}