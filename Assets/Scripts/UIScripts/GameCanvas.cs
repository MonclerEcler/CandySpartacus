using UnityEngine;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour
{
    [Header("Pause")]

    [SerializeField] private Button _pauseButton;
    [SerializeField] private GameObject _pauseCanvas;

    private void Start()
    {
        _pauseButton.onClick.AddListener(PauseHandler);
    }

    private void PauseHandler()
    {
        _pauseCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

}
