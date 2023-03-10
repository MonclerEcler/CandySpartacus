using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonMainMenu : MonoBehaviour
{
    [Header("Play")]
    [SerializeField] private Button _loadingToGame;

    private void Start()
    {
        _loadingToGame.onClick.AddListener(LoadingToFirstScene);
    }

    private void LoadingToFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}
