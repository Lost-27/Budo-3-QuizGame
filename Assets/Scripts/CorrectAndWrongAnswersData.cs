using UnityEngine;

public class CorrectAndWrongAnswersData : MonoBehaviour
{
    #region Variables

    public int CorrectAnswers; //{ get; private set; }
    public int WrongAnswers; // { get; private set; }

    private static CorrectAndWrongAnswersData _instance;

    #endregion

    public static CorrectAndWrongAnswersData Instance => _instance;


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

    #endregion
}