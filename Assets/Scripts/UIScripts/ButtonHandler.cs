using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _exitButton;

    [SerializeField] private GameObject _exitFromPauseCnavas;

    private void Start()
    {
        _restartButton.onClick.AddListener(RestartHandler);
        _continueButton.onClick.AddListener(ContinueHandler);
        _exitButton.onClick.AddListener(ExitToMainMenu);
    }

    private void RestartHandler()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        _exitFromPauseCnavas.SetActive(false);
    }

    private void ExitToMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    private void ContinueHandler()
    {
        _exitFromPauseCnavas.SetActive(false);
        Time.timeScale = 1f;
    }
}
