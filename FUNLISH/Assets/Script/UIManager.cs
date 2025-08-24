using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject goalPlayerPanel; // Panel awal
    public GameObject miniMapUI;       // Canvas / Panel minimap
    public GameObject pauseMenuUI;     // Panel pause
    public GameObject objectivePanel;   // panel objective
    private bool isGameStarted = false;
    private bool isPaused = false;

    void Start()
    {
        // Di awal game, panel muncul, minimap disembunyikan
        goalPlayerPanel.SetActive(true);
        miniMapUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        objectivePanel.SetActive(false);

    }

    public void OnStartGame()
    {
        goalPlayerPanel.SetActive(false);
        isGameStarted = true;
        miniMapUI.SetActive(true);
        objectivePanel.SetActive(true);
    }

    public void OnPauseGame()
    {
        if (!isGameStarted) return;

        isPaused = true;
        pauseMenuUI.SetActive(true);
        miniMapUI.SetActive(false); // sembunyikan saat pause
        objectivePanel.SetActive(false);
        Time.timeScale = 0f;
    }

    public void OnResumeGame()
    {
        isPaused = false;
        pauseMenuUI.SetActive(false);
        miniMapUI.SetActive(true); // tampilkan lagi setelah resume
        objectivePanel.SetActive(true);
        Time.timeScale = 1f;
    }
}
