using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [Header("UI References")]
    public GameObject pausePanel; 
    public Button continueButton;
    public Button restartButton;
    public Button mainMenuButton;

    private bool isPaused = false;

    void Start()
    {
        if (pausePanel != null)
            pausePanel.SetActive(false);

        if (continueButton != null) continueButton.onClick.AddListener(ContinueGame);
        if (restartButton != null) restartButton.onClick.AddListener(RestartGame);
        if (mainMenuButton != null) mainMenuButton.onClick.AddListener(GoToMainMenu);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) ContinueGame();
            else PauseGame();
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        if (pausePanel != null) pausePanel.SetActive(true);
    }

    public void ContinueGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        if (pausePanel != null) pausePanel.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
