using UnityEngine;

public class CorrectAndWrongAnswersData : MonoBehaviour
{
    #region Variables

    public int CorrectAnswers; //{ get; private set; }
    public int WrongAnswers;// { get; private set; }

    private static CorrectAndWrongAnswersData _instance;
    private QuizManager _quizManager;

    #endregion


    #region Unity lifecycle

    private void Awake()
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

    private void Start()
    {
        _quizManager = FindObjectOfType<QuizManager>();
    }

    private void Update()
    {
        CorrectAnswers = _quizManager.NumCorrectAnswers;
        WrongAnswers = _quizManager.NumWrongAnswers;
    }

    #endregion
}