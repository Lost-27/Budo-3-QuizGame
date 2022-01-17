using UnityEngine;
using UnityEngine.UI;

public class GameScreen : MonoBehaviour
{
    #region Variables

    public Button MenuButton;
    public Button QuitButton;

    private SceneHelper _sceneHelper;

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        MenuButton.onClick.AddListener(MenuButtonClicked);
        QuitButton.onClick.AddListener(QuitButtonClicked);

        _sceneHelper = FindObjectOfType<SceneHelper>();
    }

    #endregion


    #region Private methods

    private void QuitButtonClicked()
    {
        _sceneHelper.Quit();
    }

    private void MenuButtonClicked()
    {
        _sceneHelper.LoadScene(0);
    }

    #endregion
}
